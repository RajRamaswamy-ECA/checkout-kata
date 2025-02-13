# checkout-kata
CMap Checkout Kata Project

This is a class library written in .Net 8.0 with NUnit tests. 

This library can scan an item which is in the list of items in the database (in our case it is a csv file) and get the total items count and get total price of items added to the
basket including any offers available.

The database (csv) file can be updated with the list of items user has got and this list can be updated any time with the multi buy special offers.

The program can also be designed/extended in future as a httpclient webAPI with a front end web app to pick item from a dropdown and the quantity of items which will invoke the webapi methods with a
httprequest and http response to get the total price of scanned items.