var siteUrl = "https://www.justgiving.com/"
var apiUrl = 'https://api.justgiving.com/';
var apiKey = '88e40064';
var fundRaisingApiPath = '/v1/fundraising/pages/';
var donationsApiPath = '/donations'

$(document).ready(function() {
  
	$('.save-options').click(function(){ saveSettings() });
	var shortPageName = localStorage["shortPageName"];
	
	if(!shortPageName){
		showSettings();
	} 
	else{
		showSummary(shortPageName);
	}
});

function showSummary(shortPageName){
	$('.container').css('display', 'block');
	$('.options-container').css('display', 'none');	
	
	$.get( apiUrl + apiKey + fundRaisingApiPath + shortPageName,
		   showPageSummary);
		   
	$.get( apiUrl + apiKey + fundRaisingApiPath + shortPageName + donationsApiPath + '?PageSize=1&PageNum=1',
		   showDonationsCount);
	
	$('.page-link').click(function(){ openPageInTab(siteUrl + shortPageName) });
	$('.settings-link').click(function(){ showSettings() });
}

function showSettings(){
	$('.container').css('display', 'none');
	$('.options-container').css('display', 'block');
	$('.error').css('display', 'none');
	restoreSettings();
}

function showPageSummary(data) {
	data  = $(data);
	var target = data.find('fundraisingTarget').text();
	var raised = data.find('grandTotalRaisedExcludingGiftAid').text();
	var eventName = data.find('eventName').text();
	var thermBg = data.find('thermometerBackgroundColour').text();
	var thermFill = data.find('thermometerFillColour').text();
	

	$('.raised-so-far').text('£' + Number(raised).toFixed(2));
	$('.target').text('£' + target);
	$('.event-name').text(eventName);
	$('.base').css('background-color', '#' + thermBg);
	$('.starburst span').css('background-color', '#' + thermFill);
	$('.raised').css('background-color', '#' + thermFill)
	$('.uncover').css('background-color', '#' + thermBg)
	
	thermometer.animate(raised/target * 100)
}
	
function showDonationsCount(data){
	data  = $(data);
	var total = data.find('totalPages').text();
	$('.donations-count').text(total);
}
	
function openPageInTab(url)
{
	chrome.tabs.create({ 'url': url });
}

function saveSettings() {
	var shortPageName = $('.page-url').val();

	if(!shortPageName.match(/^(https?:\/\/)?(www\.)?justgiving\.com\/[a-z0-9-]+$/i)){
		$('.error').css('display', 'block');
	}
	
	shortPageName = shortPageName.replace(/^(https?:\/\/)?(www\.)?justgiving\.com\/?/i, '');
	
	$.ajax({
        type: "HEAD",
        url: apiUrl + apiKey + fundRaisingApiPath + shortPageName,
        success: function(){
            localStorage["shortPageName"] = shortPageName;
			showSummary(shortPageName);
        },
		error: function(){
			$('.error').css('display', 'block');
		}
    });
}

function restoreSettings() {
	var shortPageName = localStorage["shortPageName"];
	if (!shortPageName) {
		return;
	}
	$('.page-url').val('https://www.justgiving.com/' + shortPageName);
}