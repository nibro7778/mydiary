# MyDiary - Microservices and container based appliation

Sample microservice and container based application, accessed via API Gateway (ocelot). Currently I am planning to use .NET Core 2.2, Docker engine, Azure/AWS/Digital Ocean for hosting micro services, kubernetes. The goal of this project is implement the most common used technologies and share with technical community the best way to develop great application with .NET App

## Project Status

[![Gitter](https://badges.gitter.im/mydiary-app/community.svg)](https://gitter.im/mydiary-app/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
[![GithubActionWorkflow](https://github.com/actions/setup-dotnet/workflows/Main%20workflow/badge.svg)](https://github.com/nibro7778/mydiary/actions)


Project is currently in development phase. I am really happy to accept your idea which, together :couple::two_men_holding_hands: we can implement in this project and learn new technology together 🚀. Come and have a chat on gitter. 

## Give a Star! ⭐️
If you liked the project or if this project helped you, please give a star :wink:

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

Visit <a href="https://github.com/nibro7778/mydiary/wiki">wiki</a> page :newspaper: for more detail about architecture of application

## Following are technology stack used in My Diary application 

- .NET Core 2.2
- Docker
- EF Core
- Identity Server (Authorization)
- Samplified CQRS & DDD
- API gateway (ocelot)
- RabbitMQ (Public/Subscribe)


