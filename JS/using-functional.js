'use strict';

const fs = require('fs');
var _ = require('lodash');

let rawdata = fs.readFileSync('orders.json');
let orders = JSON.parse(rawdata);
let orders2 = JSON.parse(rawdata);


let ordersresult = [
    ...orders,
    ...orders2,
	...orders
];


function readFunctional(orders) {
	return _.chain(orders)
	.groupBy("country")
	.mapValues(ordersDetail => ordersDetail.map(details => details.id))
	.value();
}






console.time('test');

readFunctional(ordersresult)

console.timeEnd('test');
