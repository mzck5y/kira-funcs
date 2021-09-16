# kira-faas-sample-funcs
Some sample functions that will run on the KIRA FaaS runtime.

## To run this function 
```
docker run -d -p 8888:80 --network oni --name my-first-function [image name]
```

## To run nats server as event sourcing.
```
docker run -d -p 4222:4222 --network oni --name nats-event-server nats:2.3.4-alpine3.14
``` 