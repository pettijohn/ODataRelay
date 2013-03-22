ODataRelay
==========

- Goal: successfully consume an OData service and re-publish it as another OData service. 
-	Consumes a public OData Service on the Internet (http://services.odata.org/Northwind/Northwind.svc/)
-	Displays ten customers on a web page via LINQ query (PublicRead.aspx)
-	Re-publishes the OData service internally (a la Service Bus will do) via MyNorthwindService
-	Project LocalClient consumes the local MyNorthwindService and displays ten customers.
-	Success! The request forwards successfully to the Internet endpoint and returns the data via the locally re-published service relay

