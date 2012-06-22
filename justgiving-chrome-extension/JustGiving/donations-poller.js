var donationsPoller = (function() {

	'use strict';

	var timer = null;
	
	function start(){
		if(!timer){
			poll();
		}
	}
	
	function stop() {
		clearTimeout(timer);
		timer = null;
		datastore.saveDonationsCount('');
	}
	
	function poll(){
		if(!donationsPoller.shortPageName){ return; }
		if(!datastore.fetchNotificationsEnabled()) { return; }

		timer = setTimeout(function(){
					justgiving.getFundraisingPageDonations(donationsPoller.shortPageName, 1, 1, 
						donationsSuccess, 
						dontaionsFailure)
				}, 3000);
	};
	
	function donationsSuccess(data){
		var oldCount = datastore.fetchDonationsCount();
		var newCount = data.pagination.totalPages;
		
		if (!oldCount) {
			datastore.saveDonationsCount(newCount);
		}
		else if (newCount > oldCount) {
			// do summat
			chrome.browserAction.setBadgeText({ text: String(newCount - oldCount) });
			datastore.saveDonationsCount(newCount);
		}
		poll();
	}
	
	function dontaionsFailure(){
		poll();
	}
	
	return {
		shortPageName: null,
		start: start,
		stop: stop
		
	};
}());
  
	        