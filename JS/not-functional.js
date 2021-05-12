'use strict';
const fs = require('fs');
let rawdata = fs.readFileSync('orders.json');
let orders = JSON.parse(rawdata);

function groupBy(array, keyOrIterator) {
	var iterator, key;
  
	if(typeof key !== 'function') {
	  key = String(keyOrIterator);
	  iterator = function (item) { return item[key]; };
	} else {
	  iterator = keyOrIterator;
	}
  
	return array.reduce(function (memo, item) {
	  var key = iterator(item);
	  memo[key] = memo[key] || [];
	  memo[key].push(item);
	  return memo;
	}, {});
}

function readNotFunctional(orders) {
	const ordersGrouped = groupBy(orders, "country");
	let idsByCountry = {}

	for (const country in ordersGrouped) {
		idsByCountry[country] = []
		for (const order in ordersGrouped[country]) {
			idsByCountry[country].push(ordersGrouped[country][order].ID)
		}
	}

	return idsByCountry;
}

readNotFunctional(ordersresult)