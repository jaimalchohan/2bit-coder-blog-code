var siteUrl = "https://www.justgiving.com/"
justgiving.apiKey = '88e40064';
justgiving.apiUrl = 'https://api.justgiving.com/';

$(document).ready(function() {  
	$('.save-options').click(function(){ saveSettings() });
	var shortPageName = datastore.fetchShortPageName();

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
	
	// clear the badge text if this has been set
	chrome.browserAction.getBadgeText({}, clearBadgeText)
	
	justgiving.getFundraisingPageDetails(shortPageName, showPageSummary)
	justgiving.getFundraisingPageDonations(shortPageName, 1, 1, showDonationsCount);
	
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
	var target = data.fundraisingTarget;
	var raised = data.grandTotalRaisedExcludingGiftAid;
	var eventName = data.eventName;
	var thermBg = data.branding.thermometerBackgroundColour;
	var thermFill = data.branding.thermometerFillColour;
	

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
	var total = data.pagination.totalPages;
	$('.donations-count').text(total);
}
	
function openPageInTab(url)
{
	chrome.tabs.create({ 'url': url });
}

function saveSettings() {
	var url = $('.page-url').val();
	
	var shortPageName = justgiving.getShortPageNameFromUrl(url)

	if(!shortPageName){
		$('.error').css('display', 'block');
	}
	
	justgiving.fundraisingPageUrlCheck(
		shortPageName, 
		function(){
            datastore.saveShortPageName(shortPageName);
			chrome.extension.getBackgroundPage().donationsPoller.start();
			showSummary(shortPageName);
        },
		function(data){
			$('.error').css('display', 'block');
		}
	);
}

function restoreSettings() {
	var shortPageName = datastore.fetchShortPageName();
	if (!shortPageName) {
		return;
	}
	$('.page-url').val('https://www.justgiving.com/' + shortPageName);
}

function clearBadgeText(value){
	if(value){
		chrome.browserAction.setBadgeText({ text: '' });
	}
}