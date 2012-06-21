var justgiving = (function () {

	'use strict';

	var fundRaisingApiPath = '/v1/fundraising/pages/',
	    donationsApiPath = '/donations';

	function fundraisingPageUrlCheck(shortPageName, successCallback, errorCallback) {
		$.ajax({
			type: 'HEAD',
			cache: false,
			url: justgiving.apiUrl + justgiving.apiKey + fundRaisingApiPath + shortPageName,
			success: successCallback,
			error: errorCallback
		});
	}

	function getFundraisingPageDetails(shortPageName, successCallback, errorCallback) {
		$.ajax({
			type: 'GET',
			contentType: 'application/json',
			cache: false,
			url: justgiving.apiUrl + justgiving.apiKey + fundRaisingApiPath + shortPageName,
			success: successCallback,
			error: errorCallback
		});
	}

	function getFundraisingPageDonations(shortPageName, pageSize, pageNumber, successCallback, errorCallback) {
		$.ajax({
			type: 'GET',
			contentType: 'application/json',
			cache: false,
			url: justgiving.apiUrl + justgiving.apiKey + fundRaisingApiPath + shortPageName + donationsApiPath + '?PageSize=' + pageSize + '&PageNum=' + pageNumber,
			success: successCallback,
			error: errorCallback
		});
	}

	function getShortPageNameFromUrl(url) {
		if (!url.match(/^(https?:\/\/)?(www\.)?justgiving\.com\/[a-z0-9\-]+$/i)) {
			return null;
		}
		return url.replace(/^(https?:\/\/)?(www\.)?justgiving\.com\/?/i, '');
	}

	return {
		apiUrl: null,
		apiKey: null,
		fundraisingPageUrlCheck: fundraisingPageUrlCheck,
		getFundraisingPageDetails: getFundraisingPageDetails,
		getFundraisingPageDonations: getFundraisingPageDonations,
		getShortPageNameFromUrl: getShortPageNameFromUrl
	};
}());