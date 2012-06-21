var donationsPoller = (function() {

	'use strict';
	
	function start(){
		var shortPageName = datastore.fetchShortPageName();
	
		if(!shortPageName){ return; }
	
		poll();
	}
	
	function poll(){
		setTimeout(function(){
			justgiving.getFundraisingPageDonations(datastore.fetchShortPageName(), 1, 1, donationsUpdated)
		}, 3000);
	};
	
	function donationsUpdated(data){
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
		poll(data.id);
	}
	
	return {
		start: start
	};
}());
  
	        