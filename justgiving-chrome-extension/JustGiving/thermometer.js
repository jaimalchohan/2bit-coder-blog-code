var thermometer = (function() {

	function animate(percentageTarget){
		
		var percentageTargetCount = percentageTarget;
		var realPercentageTarget =  percentageTarget;
		
		if (realPercentageTarget > 100) {
			realPercentageTarget = 100;
		};

		var animTime = realPercentageTarget * 30;
		
		var startAnimateObject = { fillHeight: 100, percentageCounter: 0 };
		var endAnimateObject = { fillHeight: 100 - realPercentageTarget, percentageCounter: percentageTargetCount > 100 ? 100 : percentageTargetCount };
		jQuery(startAnimateObject).animate(endAnimateObject, {
				duration: animTime, 
				easing: 'linear',
				step: function () {
					$('.uncover').height(this.fillHeight);
					$('.frp-thermometer strong em').text(Math.ceil(this.percentageCounter) + "%");
				},
				complete: function() {
					if (percentageTargetCount >= 100) {
						animateHalo();
						if (percentageTargetCount > 100) {
							animatePercentageBeyond100Percent(101, percentageTargetCount);
						}
					}
					$('.frp-thermometer strong em').text(percentageTargetCount + "%");
				}
		});
	}
	
	function animateHalo() {
		$('.starburst').fadeTo(1000, 1).fadeTo(1000, 0).fadeTo(1000, 1).fadeTo(1000, 0).fadeTo(1000, 1).stop();
	};

	function animatePercentageBeyond100Percent(startPercentage, endPercentage, completeCallback) {
		jQuery({ percentageCounter: startPercentage }).animate({ percentageCounter: endPercentage }, {
			duration: (endPercentage - startPercentage) * 30,
			easing: 'linear',
			step: function() {
				$('.frp-thermometer strong em').text(Math.ceil(this.percentageCounter) + "%");
			},
			complete: function() {
				$('.frp-thermometer strong em').text(endPercentage + "%");
				if (completeCallback) {
					completeCallback();
				}
			}
		});
	}

	return {
		animate: animate
	};
}());
  
	        