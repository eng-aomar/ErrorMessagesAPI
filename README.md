# Welcome to The ErrorMessagesAPI Project
Nowadays, many applications are depoloyed on the **cloud**, using the infrastructure of the cloud providers such like AWS, Google, OVH, etc.\
**Heroku** is a Platform as a service (PaaS) that facilitates the applications deployment on the cloud.
The working engineers in this company end up with 12 principles that should be done to 
deploy a scalable, portable and ready cloud native application.


***ErrorMessagesAPI*** is a Rest API that satisfies the [12 factor methodology](https://12factor.net/).
This API exposes the CRUD (create, read, update, delete) on the *message* model\.

The API is built using the *APS.NET core*, The main domain of this API is to provide a way for others to mange their sw errors (get, get by id,add, delete) anytime.
###### will be explained later in details.

# System Requirments:

All you need to run this API is a 
### Microsoft Visual Studio Community 2019
### Docker Desktop to run Mongo Docker

# API Methods:

<table>
    <tbody>
        <tr>
            <th> HTTP verb </th>
            <th> URI </th>
            <th> Action Desc. </th>
            <th> Consumes </th>
            <th> Produces </th>
            <th> Parameters </th>
            <th> Responses </th>
        </tr>
        <tr>
            <td align="center"> GET </td>
            <td align="center"> /messages </td>
            <td align="center"> Get all messages </td>
            <td align="center"> ---- </td>
            <td align="center"> application/json </td>
            <td align="center"> ---- </td>
            <td align="center">
                <ul>
                    <li>200: Description: Get all messages </li>
                    <li> 404: Description: No messages found</li>
                </ul>
            </td>
        </tr>
        <tr>
            <td align="center"> GET </td>
            <td align="center"> /messages/id </td>
            <td align="center"> Get message by ID </td>
            <td align="center"> ---- </td>
            <td align="center"> application/json </td>
            <td align="center"> id: integer </td>
            <td align="center">
                <ul>
                    <li> 200: Description: Successfull operation </li>
                    <li> 400: Description: Invalid ID supplied</li>
                    <li> 404: Description: message not found</li>
                </ul>
            </td>
        </tr>
        <tr>
            <td align="center"> POST </td>
            <td align="center"> /messages </td>
            <td align="center"> Create a new message </td>
            <td align="center"> application/json </td>
            <td align="center"> application/json </td>
            <td align="center"> ---- </td>
            <td align="center">
                <ul>
                    <li>200: Description: Successfull operation </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td align="center"> PUT </td>
            <td align="center"> /messages/id </td>
            <td align="center"> Update the message with ID </td>
            <td align="center"> application/json </td>
            <td align="center"> application/json </td>
            <td align="center"> id: integer </td>
            <td align="center">
                <ul>
                    <li>200: Description: Successfull operation</li>
                    <li>400: Description: Invalid ID supplied</li>
                    <li>404: Description: Message not found</li>
                </ul>
            </td>
        </tr>
        <tr>
            <td align="center"> DELETE </td>
            <td align="center"> /messages/id </td>
            <td align="center"> Delete message with ID </td>
            <td align="center"> ---- </td>
            <td align="center"> ---- </td>
            <td align="center"> id: integer </td>
            <td align="center">
                <ul>
                    <li>200: Description: Successfull operation</li>
                    <li>400: Description: Invalid ID supplied</li>
                    <li>404: Description: Message not found</li>
                </ul>
            </td>
        </tr>
    </tbody>
</table>

# Contribution:
Visit the [issue tracker](https://github.com/SWEN6305CloudNative-SRA/MessagesAPI/issues) to find a list of open issues that need attention.

Fork, then clone the repo:

```
$ git clone https://github.com/SWEN6305CloudNative-SRA/MessagesAPI.git
```

Create a new branch:
```
$ git checkout -b [name_of_your_new_branch]
```
Push the branch on github :
```
$ git push origin [name_of_your_new_branch]
```

# API Specification & Testing: 
In our API we used the [Swagger OpenAPI](https://swagger.io/) for documentation. 
**Swagger** is used together with a set of open-source software tools to design, build, document, and use RESTful web services.

In order to view the documentation of our API, you are supposed to run the project and go to this link:
*https://localhost:5001/swagger*

<sub>Note: The port number may be different in your run.</sub>

![swagger](https://user-images.githubusercontent.com/55650010/100859067-773b1980-3497-11eb-86ee-260f1d881528.png)

# Context Diagram
A system context diagram (SCD) in engineering is a high level view of a system that defines the boundary between the system, or part of a system, and its environment, showing the entities that interact with it.
<img src="https://user-images.githubusercontent.com/55021862/100797714-402f1e80-342b-11eb-8e30-ab00c8866afe.png" width="800" height="600"></img>
# 1 - Codebase
*One codebase tracked in revision control, many deploys*. <br />

To achieve the first factor, we created a repository for the backend API called: ErrorMessagesAPI.
In this repository two branches have been created:

1. **main** branch for the production.
2. **dev** branch for the development.
The source code has been tracked using the Github platform, and every team member contributes using pull requests
mechanism. 

# 2 - Dependencies
*Explicitly declare and isolate dependencies*. <br />

In the twelve-factor app, we should never relies on the implicit existence of system-wide package, instead we should declare all our dependencies in a dependecy declaration manifest. This is to ensure that no implicit dependecies "leak in" from the surrounding system.

Since we are using Microsoft development platform, **NuGet package manager** is used.
The NuGet Package Manager is responsible for declaring and isolating the application dependencies and it allows you to easily install, uninstall, and update NuGet packages in projects and solutions.

In our API here is the list of installed packages:
* Microsoft.Extensions.Options (3.1.9).
* Microsoft.VisualStudio.Azure.Containers.Tools.Targets (1.10.9).
* MongoDB.Bson (2.11.3).
* MongoDB.Driver (2.11.3).
* Swashbuckle.AspNetCore (5.6.3)

Visual Studio can restore packages automatically when it builds a project, and you can restore packages at any time through Visual Studio
```
nuget restore
```
Package Restore first installs the direct dependencies of a project as needed, then installs any dependencies of those packages throughout the entire dependency graph.
# 3 - Configuration
*Store config in the environment*. <br />

The application configuration is everything that vary among deploys. These configurations should be separated from the application code. 
According to our application, the database connection string is considered a configuration and should be separated from the code, so we store that string in the user environment under the name of "ConnectioString", we also store the name of the database in an environmental variable... Below are the environment variables of our API

### Environmental Variables for the Error Message API

In the Docker Compose file, under the environment, two variables are defined (MongoDB__URL, Mongo_DB), the values of the two varaibles are stored in the OS environmental Variables.

```
    environment:
      MongoDB__URL: ${ConnectionString}
      Mongo_DB: ${DB_Name}
```
Besides, the Mongo database credentials are stored in the docker compose file such as the following:
```
environment:
      MONGO_INITDB_ROOT_USERNAME: ${MONGO_ROOT_USER}
      MONGO_INITDB_ROOT_PASSWORD: ${MONGO_ROOT_PASSWORD}
```
# 4 - Backing services
*Treat backing services as attached resources*. <br />

Anything external to a service is treated as an attached resource, including other services. In general, backing services are those that our application consumes over the network as part of its normal process.
In our case, MongoDB is considered a backing service, that can be accessed using the credentials stored in the config file (see factor #3).
Applying this factor ensures that every service is completely portable and loosely coupled to the other resources in the system.  Strict separation increases flexibility during development, developers only need to run the services they are modifying, not others.  A database (Mongo DB) should be referenced by a simple endpoint (URL) and credentials, if necessary. 


# 5 - Build / Release / Run
*Strictly separate build and run stages*. <br />

Build / Release and Run phases must be kept separated.
In order to transform our codebase to a deploy, we should pass 3 stages: 
1- *Build stage*, where the code repo is converted to an executable bundle called **build**. In this stage, adll dependencies are fetched and the binaries files are complied.
2- *Release stage*, where we combines the build produced in the previous stage, with the deploy config. Therefore, ready to be executed. Note that each release must have a unique ID, and using the release management tools we can rollback to previous releases.R
3- *Run stage*, where we run the application in the execution environment.

A release is deployed on the execution environment and must be immutable.

## What does that mean for our application ?

We'll use Docker in the whole development pipeline. We will start by adding a Dockerfile that will help define the build phase (during which the dependencies are compiled in _node-modules_ folder)

## Multi-stage build

The multi-stage build feature helps make the container building process more efficient, and it also makes containers smaller by letting them contain only the bits your application needs at runtime. The multi-stage version is used for .NET Core projects.

```
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MessagesAPI/MessagesAPI.csproj", "MessagesAPI/"]
RUN dotnet restore "MessagesAPI/MessagesAPI.csproj"
COPY . .
WORKDIR "/src/MessagesAPI"
RUN dotnet build "MessagesAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MessagesAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MessagesAPI.dll"]

```
### Base Stage
The lines in the Dockerfile begin with the Buster image from Microsoft Container Registry (mcr.microsoft.com) and create an intermediate image base that exposes ports 80 for HTTP and 443 for HTTPS, and sets the working directory to /app.

The next stage is build, which appears as follows:

```
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MessagesAPI/MessagesAPI.csproj", "MessagesAPI/"]
RUN dotnet restore "MessagesAPI/MessagesAPI.csproj"
COPY . .
WORKDIR "/src/MessagesAPI"
RUN dotnet build "MessagesAPI.csproj" -c Release -o /app/build
```

### Build Stage
The build stage starts from a different original image from the registry (sdk rather than aspnet), rather than continuing from base. The sdk image has all the build tools, and for that reason it's a lot bigger than the aspnet image, which only contains runtime components. The reason for using a separate image becomes clear when you look at the rest of the Dockerfile:

### Final Stage

```
FROM build AS publish
RUN dotnet publish "MessagesAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MessagesAPI.dll"]
```

The final stage starts again from base, and includes the COPY --from=publish to copy the published output to the final image. This process makes it possible for the final image to be a lot smaller, since it doesn't need to include all of the build tools that were in the sdk image.

Let's build our application `$ docker build -t MessageAPI .`

And verify the resulting image is in the list of available images

```
$ docker images
REPOSITORY                             TAG                   IMAGE ID            CREATED             SIZE
messagesapi                            dev                   bccbbeb61b61        9 hours ago         347MB
mcr.microsoft.com/dotnet/core/aspnet   3.1-nanoserver-1903   08f393180806        2 weeks ago         347MB
```

Now the image (build) is available, execution environment must be injected to create a release.

There are several options to inject the configuration in the build, among them
* create a new image based on the build
* define a Compose file

We'll go for the second option and define a docker-compose file where the MONGO_URL will be set with the value of the execution environment

```
version: '3.4'

services:
  errormessagesapi:
    image: ${DOCKER_REGISTRY-}errormessagesapi
    container_name: error-messages-api
    build:
      context: .
      dockerfile: Dockerfile
    environment:
      MongoDB__URL: ${ConnectionString}
      Mongo_DB: ${DB_Name}
    depends_on:
      - mongo
    networks:
      - error-messgeapi-network
  mongo:
    image: mongo
    container_name: mongo
    restart: always
    ports:
      - '27017:27017'
    environment:
      MONGO_INITDB_ROOT_USERNAME: ${MONGO_ROOT_USER}
      MONGO_INITDB_ROOT_PASSWORD: ${MONGO_ROOT_PASSWORD}
    volumes:
      - mongo-data:/data/db
     #- ./mongo/docker-entrypoint-initdb.d:/docker-entrypoint-initdb.d
    networks:
      - error-messgeapi-network

  mongo-express:
    image: mongo-express
    container_name: mongo-express
    restart: always
    ports:
      - 8081:8081
    depends_on:
      - mongo
    networks:
      - error-messgeapi-network
volumes:
  mongo-data:
    driver: local
networks:
  error-messgeapi-network:
    driver: bridge
```
In the Dockor-Compose we connect three images ( MessagAPI, Mongo, Mongo-express). Docker compose creat the defualt network between the images. Regarding the mongo image, we define the mongo-data volume locally inside the conatiner to presist the data. The Mongo-express is used to provide a simple interface to the mongo database.  Mongo-express can be accessed using the following url (http://localhost:8081/). By defualt mongo database has alreday three pre-defined databases as the picture shows. We add messagedb database and Message collection to it.
![mongo-express](https://user-images.githubusercontent.com/55650010/100858792-1c092700-3497-11eb-9e8e-a9f280afb10c.png)

This file defines a release as it considers a given build and inject the execution environment.

The run phase can be done manually with Compose CLI or through an orchestrator (Docker Cloud).

Compose CLI enables to run the global application as simple as `docker-compose up -d`

**Note:** When this command is executed, Docker Compose will pull all the images necessary for the setup, generate all the services configured in the Docker Compose file, create the network between the containers, set the environment variables for the containers, and expose the configured ports.

![conatiners](https://user-images.githubusercontent.com/55650010/100858948-4eb31f80-3497-11eb-85b6-69d243525145.PNG)


Fork, then clone the repo:

```
$ git clone https://github.com/SWEN6305CloudNative-SRA/MessagesAPI.git
```

Create a new branch:
```
$ git checkout -b [name_of_your_new_branch]
```
Push the branch on github :
```
$ git push origin [name_of_your_new_branch]
```

## Continuous Integration

Below is the YAML File
```
name: .NET

on:
  push:
    branches: [ master ]
  pull_request:
    branches: [ master ]

jobs:
  build:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v2
    - name: Setup .NET
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 3.1.402
    - name: Restore dependencies
      run: dotnet restore "ErrorMessagesAPI.csproj"
    - name: Build
      run: dotnet build "ErrorMessagesAPI.csproj" --no-restore
    - name: Test
      run: dotnet test  "ErrorMessagesAPI.csproj" --no-build --verbosity normal
```

## Continuous deployment

After the code is buit successfuly, it is then depolyed to the Docker Hub (sraorganaization) o the errormessageapi repository.

```
name: push to docker hub (CD)

on:
  push:
    branches: [ master ]
  pull_request:
    branches: [ master ]

jobs:

  build:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v2
    - name: docker login
      env:
        DOCKER_USER: ${{secrets.DOCKER_HUB_USERNAME}}
        DOCKER_PASSWORD: ${{secrets.DOCKERHUB_TOKEN}}
      run: |
        docker login -u $DOCKER_USER -p $DOCKER_PASSWORD 
    - name: Build the Docker image
      run: docker build . --file "./Dockerfile" --tag ${{secrets.DOCKER_ORGANIZATION}}/errormessageapi
      
    - name: Docker Push
      run: docker push ${{secrets.DOCKER_ORGANIZATION}}/errormessageapi
```

 ## Deploy To kubernetes (Loacaly) 
 The Following steps are followed to setup K8s
 
Start a cluster by running:
```
minikube start
```
To access Kubernetes dashboard of the started cluster we run:
```
minikube dashboard
```
Now we can interact with our cluster using the **"Kubectl"**

### Deploy Conatiner to K8s:
To deploy to k8s, we created a service and a depolyment configration yml file.

  ```
  apiVersion: v1
kind: Service
metadata:
  name: errormessage-api-service
  namespace: default
spec:
  selector:
    app: error-messagepi-pod
  ports:
    - protocol: TCP
      port: 8080
      targetPort: 80
  type: LoadBalancer 

---
apiVersion: apps/v1
kind: Deployment
metadata:
  name: errormessage-api-deployment
  namespace: default
  labels:
    app: error-messagepi-pod
spec:
  replicas: 2
  selector:
    matchLabels:
      app: error-messagepi-pod
  template:
    metadata:
      labels:
        app: error-messagepi-pod
    spec:
      containers:
      - name: errormessageapi-container
        image: sradockerization/errormessageapi:latest
        imagePullPolicy: IfNotPresent   
        resources:
          requests:
            cpu: 100m
            memory: 128Mi
          limits:
            cpu: 500m
            memory: 128Mi
  ```


 
 ![image](https://user-images.githubusercontent.com/55650010/105977832-82c34f00-609a-11eb-9df8-24f9424bc07d.png)
 
 To deploy the image to kubernetes, the following command is used:
 
```
kubectl apply -f .\k8s\error_message_api_deployement.yml
```

The following are the service, deployment and pods of our deployed image
```
kubectl get all
```
```
NAME                                               READY   STATUS    RESTARTS   AGE
pod/errormessage-api-deployment-5cf9674f8f-s4l42   1/1     Running   0          23h
pod/errormessage-api-deployment-5cf9674f8f-xbgmx   1/1     Running   0          23h

NAME                               TYPE           CLUSTER-IP    EXTERNAL-IP   PORT(S)          AGE
service/errormessage-api-service   LoadBalancer   10.96.73.70   localhost     8080:31402/TCP   3d20h
service/kubernetes                 ClusterIP      10.96.0.1     <none>        443/TCP          24d

NAME                                          READY   UP-TO-DATE   AVAILABLE   AGE
deployment.apps/errormessage-api-deployment   2/2     2            2           3d20h

NAME                                                     DESIRED   CURRENT   READY   AGE
replicaset.apps/errormessage-api-deployment-5cf9674f8f   2         2         2       23h
```
# 6- Processes
*Execute the app as one or more stateless processes*. <br />
Every meaningful business application creates, modifies, or uses data. In IT, a synonym for data is state. An application service that creates or modifies persistent data is called **stateful component**. In general, database services are stateful component. On the other hand, application components that do not create or modify persistent data are called **stateless components**.
Stateless components are *easier* and *simpler* to handle and can be easily scaled-up and down compared with stateful components. Moreover, they can easily restarted on a completely different node because they have no persistent data associated with them. 

# 7- Port Binding
*Export services via port binding*. <br />
This factor talks about exposing the application services to the outside world using port binding.
In general, docker containers can connect to the outside world without further configuration, but the outside world cannot connect to Docker containers by default. To allow communication between different containers in the same network we need to publish our container on one or more ports, and this is done by the **expose command**.  
In our DockerFile, we put the **Expose 80** command (we can put any port number), this tells Docker that our container’s service can be connected to on port 80.
**Note**: The ports are configured with the "HOST_PORT:CONTAINER_PORT" syntax.

# 8- Concurrency
*Scale out via the process model*. <br />

Sometimes the application becomes bigger and can't handle all coming request, therefore we need to do a horizontal scaling that means to create multiple and concurrent processes (instances), and then distribute the load of your application among those processes.

In our application, this can be done using the docker-compose file, by using the *--scale* to run multiple instances of a service.
Here is the syntax: 
```
docker-compose up --scale SERVICE_NAME=NUM_OF_SERVICES
```
However, once we try to run this command, an error occures because we are trying to map NUM_OF_SERVICES on the same port on our docker host engine. To solve this problem, we should remove the **port** from the docker-compose file, but using this approach we can't know the ports to access these services until the containers are started. To know the different processes we run this command:
```
docker-compose ps
```
For more details, you can click [here]: {https://pspdfkit.com/blog/2018/how-to-use-docker-compose-to-run-multiple-instances-of-a-service-in-development/}.

Moreover, Kubernetes also allows us to scale the stateless application at runtime by defining the **ReplicaSet**, where it automatically scale the number of pods with that number.

# 9- Disposability
*Maximize robustness with fast startup and graceful shutdown*. <br />
The different instances of our application are disposable, which means that they can started or stopped at any moment. This actually facilitate the scalability and deployment for the application.
This is achieved in out application when we use **volumes**, storing long-term persistent data outside the container (in an external-to-Docker database, in Docker volumes) means that we can desdtriy any container without affecting the user experienceز


# 10- Dev/prod parity
*Keep development, staging, and production as similar as possible.*

Historically, there have been substantial gaps between development (a developer making live edits to a local deploy of the app) and production (a running deploy of the app accessed by end users). These gaps manifest in three areas:

The time gap: A developer may work on code that takes days, weeks, or even months to go into production.
The personnel gap: Developers write code, ops engineers deploy it.
The tools gap: Developers may be using a stack like Nginx, SQLite, and OS X, while the production deploy uses Apache, MySQL, and Linux.

What does that mean for our Application?
WE use  continuous deployment to minimize the gap between deveoplment and production, by pushing the docker image continously into docker hub on push and pull reguest of the 
master branch.

# 11- Logs
*Treat logs as event streams*.  </br>
Logs are the stream of aggregated, time-ordered events collected from the output streams of all **running processes and backing services.**

The ```docker logs [OPTIONS] CONTAINER_NAME``` command shows information logged by a running container.
For more details you can read [this article] {https://docs.docker.com/engine/reference/commandline/logs/}

# 12- Admin processes
*Run admin/management tasks as one-off processes.*
