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

	return {
		fetchShortPageName: fetchShortPageName,
		saveShortPageName: saveShortPageName,
		fetchDonationsCount: fetchDonationsCount,
		saveDonationsCount: saveDonationsCount
	};
}());