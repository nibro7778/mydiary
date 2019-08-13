# My Diary - Microservices Architecture and container based appliation

Sample microservice and container based application, accessed via API Gateway (ocelot). Currently we are using .NET Core 2.2, Docker engine, Azure/AWS for hosting micro services, kubernetes. My dairy application is design to exploring "wave" of technologies like EF Core, ASP.NET Core.

## Architecture overview

The architecture proposes a microservice oriented architecture implementation with multiple autonomous microservices which means each owning its own data/db and implementing using simple data driven desing and Domain driven desing using CQRS partten using http as communication protocol and asynchronous communication using event bus (RebbitMQ)

- API Gateway 
- Identity Server
- Internal Services
  - Contact service
  - Note service
  - Event service

<p>
<img src="doc/architecturedesign.PNG">
<p>

Visit <a href="https://github.com/nibro7778/mydiary/wiki/Architecture">wiki</a> page for more detail about architecture of application

## Following are technology stack used in My Diary application 

- .NET Core 2.2
- Docker
- EF Core
- Identity Server (Authorization)
- Samplified CQRS & DDD
- API gateway (ocelot)
- RabbitMQ (Public/Subscribe)


