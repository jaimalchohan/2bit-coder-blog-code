var datastore = (function () {

	'use strict';

	function fetchShortPageName() {
		return localStorage["shortPageName"];
	}

	function saveShortPageName(value) {
		localStorage["shortPageName"] = value;
	}
	
	function fetchDonationsCount() {
		return localStorage["donationsCount"];
	}
	
	function saveDonationsCount(value) {
		localStorage["donationsCount"] = value;
	}

	function fetchNotificationsEnabled() {
		var value = localStorage["notificationsEnabled"];
		if(value == null) {
			return true;
		}
		else if(value == 'true') {
			return true;
		}
		else {
			return false;
		}
	}
	
	function saveNotificationsEnabled(value) {
		localStorage["notificationsEnabled"] = value;
	}
	
	return {
		fetchShortPageName: fetchShortPageName,
		saveShortPageName: saveShortPageName,
		fetchDonationsCount: fetchDonationsCount,
		saveDonationsCount: saveDonationsCount,
		fetchNotificationsEnabled : fetchNotificationsEnabled,
		saveNotificationsEnabled: saveNotificationsEnabled
	};
}());