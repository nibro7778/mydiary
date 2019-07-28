# My Diary - Microservices Architecture and container based appliation

Sample microservice and container based application, accessed via API Gateway (ocelot). Currently we are using .NET Core 2.2, Docker engine, Azure/AWS for hosting micro services, kubernetes. My dairy application is design to exploring "wave" of technologies like EF Core, ASP.NET Core.

## Architecture overview

The architecture proposes a microservice oriented architecture implementation with multiple autonomous microservices which means each owning its own data/db and implementing using simple data driven desing and Domain driven desing using CQRS partten using http as communication protocol and asynchronous communication using event bus (RebbitMQ)

- Contact service
- Note service
- Event service

### Contact service

This micro service contains set of APIs which are used for managing contacts. Contact details are address, email, phone number etc. 

### Note services

Note taking service. you can note whatever's in your mind just for your future reference. you can connect each note with your contact and event

### Event service 

Manging your events like small meetups with date time. you can connect your event service with contact and note service.

## Following are technology stack used in My Dairy application 

- .NET Core 2.2
- Docker
- EF Core
- Identity Server (Authorization)
- Samplified CQRS & DDD
- API gateway (ocelot)
- RabbitMQ (Public/Subscribe)
