# Function my-first-function
my-first-function Is the responsable to [INSERT BUSINESS FUNCTIONALITY] 

## To run this function 
```
docker run -d -p 8888:80 --network oni --name my-first-function [image name]
```

## To run nats server as event sourcing.
```
docker run -d -p 4222:4222 --network oni --name nats-event-server nats:2.3.4-alpine3.14
``` 