# _GGListEventSourcing
GG for ListEventSourcing


Install EventStore Fist on
https://eventstore.org/




1.Start EventStore
EventStore.ClusterNode.exe --db ./db --log ./logs


2.Admin Page
http://localhost:2113
user: admin
pass: changeit 


3.Add Projection
EventStore.ClusterNode.exe --run-projections=all --start-standard-projections=true
