## 1-1 Introduction
**Duration: 5 minutes**

Hi, my name is Mehmet Ozkaya and Welcome to my course, Deploying .Net Microservices with K8s,

Azure Kubernetes Services (AKS) and Automating with Azure DevOps.

I am a software architect and currently focusing on microservices and automation deployments.

In this course, we're going **to** learn how to Deploying .Net Microservices into Kubernetes, and moving

deployments to the cloud Azure kubernetes services (AKS) with using Azure Container Registry (ACR). And last section is

We will learn how to Automating Deployments with Azure DevOps and GitHub. You can see here, the steps

of our core structure, We're going to containerize our microservices on docker environment, and push

push these images to the DockerHub and deploy microservices on Kubernetes. As the same setup,

We are going to shifting to the cloud for deploying Azure Kubernetes Services (AKS) with pushing images to

Azure Container Registry (ACR).

Also we will cover additional topics that; Docker compose microservices, K8s components,

Zero-downtime deployments, Using azure resources like ACR, AKS

and Automate whole deployment process with writing custom pipelines with Azure DevOps and Azure Pipelines.

So See the overall picture. You can see that we will have 3 microservices which we are going to develop

and deploy together.

The first one is the Shopping.Client MVC Application

First of all, we are going to develop Shopping MVC Client Application For Consuming Api Resource

which will be the Shopping.Client Asp.Net MVC Web Project.

But we will start with developing this project as a standalone Web application which includes

own data inside it.

And we will add container support with DockerFile, push docker images to Docker hub , and see the deployment options

deployment options like "Azure Web App for Container" resources for 1 web application. Shopping.API Application

After that we are going to develop Shopping.API Microservice with MongoDb and Compose All Docker Containers.

Compose All Docker Containers.

This API project will have Products data and performs CRUD operations with exposing API methods

for consuming from Shopping Client project.

We will containerize API application with creating dockerfile and push images to Azure Container Registry.

Azure Container Registry.

And of course, we have a Mongo DB, our API project will manage product records stored in a no-sql mongodb database

as described in the picture.

we will pull mongodb docker image from docker hub and create connection with our API project.

At the end of the section, we will have 3 microservices whichs are Shopping.Client - Shopping.API -

MongoDb microservices.

As you can see that, we have created docker images, compose docker containers and tested them

in our local computers.

Deploy these docker container images on local kubernetes clusters, and push our image to ACR,

shifting deployment to the cloud Azure kubernetes services (AKS), update microservices with zero-downtime deployments.

zero-downtime deployments. And the last step, we are focusing on automation deployments with creating ci/cd pipelines

pipelines on azure devops tool.

So we will develop seperate microservices deployment pipeline yamls with using Azure Pipelines.

When we push code to Github, microservices pipeline triggers, build docker images and push the ACR

ACR and deploy to Azure Kubernetes services with zero-downtime deployments and automating

the whole process.

In the last section, we will give assignment for deploying multi-container microservices applications

with automating ci/cd pipelines.

We had developed run-aspnetcore-microservices reference application before this course.

You can see the overall picture of the reference microservices application.

microservices application.

Now, I am expecting to you, developing pipelines yamls files for deploy microservices to AKS

and update microservices with zero-downtime deployments.

By the end of this course, you'll learn how to deploy your multi-container microservices applications

with automating all deployment process separately. Before beginning the course,

You should be familiar with C#, ASP.NET Core and Docker.

And Docker. This course will have

will have good theoretical information but also will be 90% of hands-on deployment and development activities.

All microservices and deployment steps will developed step by step and together.

I hope you'll join me on this journey and develop this project with me. 

## 1-2 Prerequisites and Source Code
**Duration: 3 minutes**
In this video we are going to talk about prerequisites. First of all you don't need to know anything

about Deploying Microservices.

We will cover these topics in the courses.

But this course assumes you have some basic knowledge of C#, .Net Web Applications and Docker Container knowledge.

And Microservices knowledge would be plus.

Nevertheless, I will develop all parts from scratch so you don't need to worry about that.

We will see all the definitions of Docker Container Process, Container Registries like DockerHub or Azure Container Registry (ACR),

Deploy to Azure App Service for Containers, K8s,

AKS and Azure pipelines for automation.

You can find full source code on github, I am sharing the link in the resource of this video.

You can fork the repository and if you have any findings of expectations please open an issue on github as well as

writing to me on Q&A of the course. I am quick responder on Q&A section.

Also we are going to create a new repository and step by step develop together from scratch. no worries.

No worries.

Bu the main repo will store in aspnetrun organization in github which I can refactor or add

add other features apart from the course.

Let's have a look at the tooling we'll use.

We will use Visual studio 2019 and Visual Studio Code for IDE developments.

I will use both of them because these tools have great features for functionality.

We will use Visual studio 2019 for developing and dockerize our microservice application.

And We will use Visual Studio Code for writing k8s and aks manifest files and deploying microservices

on k8s clusters. And writing your own pipelines

for ci/cd devops flows. VS Code has great extentions for it.

Docker Desktop and Docker Account for pushing images Docker Hub

We will have used the Docker account, so we will need to Docker Desktop and Docker Account for

you.

And we will also use Git on Local and Github Account for granting our devops pipelines triggering

when push the code.

And we will need to Free Azure Subscription for creating all azure resources like ACR,

Web app for Containers, AKS and so on..

Also, we need to Azure Devops Account for ci/cd devops pipelines. So you don't need to create

now.

I will assist you when required to these tools and subscriptions. All are free and

you can deploy your own microservices with using azure free subscriptions.
## 1-3 What is Docker and Container ?
**Duration: 1 minute**
In this video we are going to talk about What is Docker and What is Container. Docker is

an open platform for developing, shipping, and running applications. Docker provides to separate your applications

from your infrastructure so you can deliver software quickly. Advantages of Docker’s methodologies

for shipping, testing, and deploying code quickly,

you can significantly reduce the delay between writing code and running it in production.

Docker provides for automating the deployment of applications as portable, self-sufficient containers

that can run on the cloud or on-premises.

Docker containers can run anywhere, in your local computer to the cloud.

Docker image containers can run natively on Linux and Windows machines.

And a container is a standard unit of software that packages up code and all its dependencies

so the application runs quickly and reliably from one computing environment to another.

A Docker container image

is a lightweight, standalone, executable package of software that includes everything needed to run an application.
## 1-4 Docker Containers, Images, and Registries
**Duration: 2 minutes**
In this video we are going to talk about Docker containers, images, and registries. When using Docker,

a developer develops an application and packages application with its dependencies into a container image.

image.

An image is a static representation of the application with its configuration and dependencies.

In order to run the application, the application’s image is instantiated to create a container,

which will be running on the Docker host. Containers can be tested in a development local machines.

Developers should store images in a registry, which is a library of images and is needed when deploying to production orchestrators.

the production orchestrators.

Docker images are stores a public registry via Docker Hub; other vendors provide registries

for different collections of images, including Azure Container Registry.

Alternatively, enterprises can have a private registry on-premises for their own Docker images.

As you can see the images shows, how docker components related each other. Developer creates container

in local and push the images the Docker Registry.

Or its possible that developer download existing image from registry and create container

from image in local environment.

If we look at the more specific example of Application Containerization with Docker, First, we should

write dockerfile for our application, Build application with this docker file and creates the docker images.

docker images. And lastly run this images on any machine and creates running docker container from docker image.

We will use all steps with orchestrating whole microservices application with docker and

Kubernetes for the next sections.
## 2-1
In this section we are going to Building MVC Client Application For Consuming API Resource which will

be the Shopping.Client Project. But this time, we will start with developing simple MVC application

before integrate with API project.

Let's check our big picture and see what we are going to build one by one.

As you can see that, we are in here and start to developing Shopping MVC Web Application project.

Shopping MVC Web Application project.

First, We will develop this project as a standalone Web application which includes own data inside it.

it, and we will add container support.

with Dockerfile, push docker images to Docker hub and see the deployment options like "Azure Web App for Container"

resources for 1 web application.

So in this section, we are going to develop Shopping.Client MVC application which will be standalone

web application and includes own data.

Next sections we will consume the Shopping.API project.

After we’ve learned the basics, we can start with the coding part.
## 2-2
In this video, we are going to create a net core MVC web application for shopping client microservices.

Let's take an action.

Before we start, let me show you our GitHub repository, which we are going to develop and deploy step

by step together.

So as you can see that it is empty repository on GitHub.

You can also start with creating new repository for you on GitHub.

Now we will clone this repository.

After that we will start creating a new project.

Let me click the code section and copy the clone URL.

Open the Visual Studio, click the clone repository pasting in here and the pet is run slash DevOps.

Okay, let me clone this application and see what's happened.

So as you can see, that it is retrieving objects from the GitHub and we will use this repository during

the course.

So yes, our repository is cloned, but there is no any solution or Visual Studio project yet.

For that purpose, let me click the file new project.

We are going to create new project.

And I'm going to select the blank solution for now.

And the solution name will be the shopping.

And of course we should provide our folder structure which is related to our GitHub repository.

You can verify in here our repository name is run slash DevOps.

Okay.

We give the solution name as a shopping and we are going to create new solution and just hit the create

button.

Yes, we have now only one solution.

And if you see the git chains, you can see the Our Solution folder created under the GitHub repository

with creating new shopping folder.

So now I'm able to create new projects under this solution item.

So let me right click add new project.

This time we are going to create ASP.Net Core web application.

And the web application name should be the shopping dot client.

Okay.

Under the shopping folder, we have a shopping cart client project, which is the MVC project.

Let me click the create button.

And you should select the ASP.Net Core MVC model view controller, and we are not going to use Https

now and make sure that you are using the MVC template.

And the Net framework is ASP.Net Core 5.0.

Let's hit the Create button and creating our first microservice, which is the shopping client.

It takes some time.

Okay?

Yes.

After that, let's modify the launch settings in order to set port numbers correctly From our big picture

of our architecture.

Let me right click properties and click the debug section.

And we are going to select this shopping dot client.

And our port number will be the 5001.

Okay, I'm saving these lunch settings and finally we can run our application.

Let me select the running profile.

We would like to choose shopping client and run this profile.

This will be the our first microservice and we will start with the standalone application and after

that we will integrate with the API project.

But let's go step by step.

Yes, as you can see that the project is running and 5.1 and everything seems okay.

In the next video we are going to develop this application.
## 2-3 Adding Model Class into MVC Application
**Duration: 1 minute**
In this video, we are going to add modal class into our MVC application.

Let's take an action.

As you know that we are using the model view controller MVC template.

So that's why we have a models folder.

So I'm going to add new modal class, right click add new item.

And the name is the model class will be the product.

Okay, In the product class, we should provide some of the properties.

So I am just copy and paste these properties.

ID name, category description, image file and the price.

So these modal class will be used during the course with shopping client and the API project.

Let's continue with the controller part.
## 2-4 Developing Shopping.Client Microservices Data Model and Context Objects
**Duration: 2 minutes**
In this video we are going to develop shopping client, microservices, data model and context objects.

So let's take an action.

Before we start, I would like to mention about every microservice should have its own database, so

we should create data store for shopping client microservices for shopping client microservice.

I will use static list objects values in order to store product data.

This is the first step.

Our development.

We will create a standalone MVC client application with data folder and deploy this application onto

Azure.

After that, we will continue to develop with consuming products from the shopping API project and compose

all microservices on Docker compose and moving to Kubernetes environments.

So let me focus one standalone microservice for now.

In order to use product class as an entity object, we should create a context class which should store

our product information.

So I'm going to start with creating data folder right click add new folder, which name is data, and

I'm going to add new class under the data object new item.

And for the context.

Okay, Now for this time, we are using the product data inside of this static class.

That's why I'm making the static class and I'm providing the static method for storing the products.

Let me copy and paste in here.

The products should be come from the.

Moodle namespace.

Okay.

As you can see that we have a product context class and storing the products in this class we define

products, read only list object and setting some products entities when object is initializing.

By this way we can simulating that product objects store in product context object.

As you can see that we can implement the product context object like entity framework core in-memory

implementation in order to store our products related data into its own database.
## 2-5 Listing Products on Index Page of Shopping.Client Microservice
**Duration: 3 minutes**
Let's open the wives home and.

Before that, we should go to the home controller.

Let me go to the home controller.

We are going to listing products into the index page.

So that's why first I navigate the index.

But this index page operations handle from the home controller class.

So that's why we should change the our index method of the home controller.

So into the view object, I am returning the products in here.

Let me paste the parameter product.

Context.

And of course we should import the data folder and using the products hard coded list object in here

we are passing these products into that.

We've.

So we have now products on index page.

We should map these data into HTML list objects.

So for that purpose after that, let me modify the index HTML.

So I'm going to copy and paste because this is the basic operations and.

Basically I'm providing to some HTML table and listing the object with the for each keyword.

Of course I'm passing the product I enumerable list in here because we were passing in the home controller

products list.

So that's why I'm passing these products and can be iterating in the HTML table objects.

Okay, finally we can run our application.

Let me run our application.

And see what happened.

Yes, as you can see that we have finished two products MVC client application.

Next step we will dockerize this application.
## 2-6 Create Docker Container for Shopping.Client Microservice
**Duration: 5 minutes**
In this video, we are going to create Docker container for our shopping client microservices.

For creation Docker container.

We need to create Docker file for our application.

This is very easy to using Visual Studio tooling features.

Let's take an action now.

First, we are going to add Docker support on our Visual Studio solution.

So I'm going to right click the shopping client application and you will see the Add button and you

will see the Add Docker support.

Let me hit this Docker support.

Or selecting the target operating system will be the Linux just hitting the.

Okay.

So this operation creates a new Docker file for us.

As you can see, that Docker file is created and also it will perform this Docker file operation into

the Visual Studio.

Let's see the Docker file.

Let me open Docker file.

We can examine the Docker file.

The Docker file, which we will make the necessary settings for the Docker.

And automatically, as you can see, that generated.

The purpose of creating the Docker file is when we ask Docker to extract the image of our project,

it will search for a file which name is Docker file in the project.

So this will make our application work accordingly to the settings in our file into the docker.

So see the files.

As you can see that it is start with the from and it is has some additional keywords.

Worker expose copy and run commands.

Basically Docker file consists of two main parts.

The first part.

The first part is the building, the application, and the second part is the running the application.

This part is building and this part is the publishing and running the application.

If we look at the commands area in here, the from part where the base image is specified in whichever

library the from project is used.

In this project, we are retrieving ASP.Net five image.

Starting from that image, we are taking this the base image.

If you look at what command are using for us, we are using the.

Net five SDK.

And the work command.

It is a part where we specify the folder under which folder location.

Docker container will copy the files for our project and this will copy files for us the app folder

location.

And of course we have a copy.

Command copy is the command used by copy project files from local file system to Docker image.

In our project we will first copy and restore the C-sharp project file.

After that, copy all these files again and create our application by running the Dotnet publish command.

And also one of the main command is run.

It is used for the commands that we need to run while the containers are being prepared.

First, it is ensured that the build is taken and then it is published.

The operation.

And another point is the entry point.

Entry point is the command that we specify for the first command and parameters that will run when the

container is up.

While the container is running the example.

For example, in our case shopping cart dot HTML.

This will be executed with the net command.

Okay.

We see the docker file and the command explanations.

Now let me check output for logs.

Let me open the output.

As you can see that we have a container tools and in the container tools Docker desktop is installed.

It is trying to verify the desktop, but our docker is not running for now.

If my docker was running, you will see that this Docker file will be building on the on the docker

of your local computer and we will see the outputs of that places.

So we need firstly start with Docker now and after that we will see how to use this Docker file.

But let me start the Docker also.

You should start from the docker on your local computer.
## 2-7 Run Docker Container for Shopping.Client Microservice
**Duration: 6 minutes**
In this video, we are going to run Docker container for our shopping client microservices.

Last video we have created Docker file.

Now we are going to run container on our local and also debug the application from Docker container.

Let's take an action before we start.

Make sure that you have installed and started Docker desktop application for your local computer.

You should download Docker desktop from this page and start Docker on your local computer and you should

see the Docker icon on your computer is running about that.

Okay, Let me return to our quotes.

As you can see that we have created Docker file in the last video.

So now once you edit the Docker file, you will see the run profile change as a docker.

Docker.

As you can see that there is a new running profile which name is the came in here.

So that's automatically arranged by the Visual Studio.

If there is a Docker file which is adding the Docker run profile, if you click the run Docker, this

will create a container from your Docker file image and run this container in your local computer.

Also, it is giving ability to debug your container with the Visual Studio.

It is very good feature from the Visual Studio.

So let's see where Visual Studio store these running profiles.

You can click the properties folder and see the launch settings.

All running profiles turning in here.

And as you can see, that Docker running profile came in here which generating from the Visual Studio.

Once we adding the Docker support and the Docker file generated.

Okay, now we can run directly this Docker profile.

Just click to the profile and it will start with some of the Docker commands.

Basically, we just do abstract these Docker commands from us for now.

We will examine later, but you can think about that.

Basically it is creating a Docker image from this Docker file, pulling this base image from the Docker

up and running the application in our local.

As you can see that I was putting the breakpoint in the index so we can see the breakpoint in here and

we can debug and inspect some of the Visual Studio objects.

And after that, as you can see that this application is running from the Docker container.

And also we can debug the Docker container from the Visual Studio.

It is very great, powerful feature.

You can debug inside of the Docker container and also you can develop and you can start with the develop

and directly inside of the Docker computer.

We are ready about the shipment at any of the code because we can also debugging and also building our

documents.

So let me show you the Visual Studio part.

As you can see that we have a container window in here.

In the container window, we see that the running containers listing in here, you can stop or close

the container image with these two link operations.

Also, you can see the environment variables, ports, logs, tricks directly comes from the ASP.Net

Logs.

As you can see that these are the ASP.Net Startup logs and you can see the inspector files inside of

the Docker container.

So it is very powerful feature when we are using the objects with Visual Studio.

We seen that the Docker image created from the running profile and we have also debug these application

with putting these debugger debugging Docker container inside of the Docker images and also Visual Studio

attaching the container process and able to debug inside of the container.

And we are developing directly inside of Docker container and it is really about the shipment at any

code level changes.

And we saw that there is a very good window which is a container tabs.

You will see the images and the containers in here.

First of all, it is downloading these images from looking the Docker file.

Let me open the Docker file.

As you can see that the first base image is ASP.Net five image.

And you can see the in here we have downloaded image ASP.Net five.

And over that we have creating a new image which is the shopping client with dev, target image and

now shopping client is running on our local computer and you can see the logs and you can debug the

applications.

All is very integrated with the Visual Studio and very good tooling experience with Visual Studio.

But behind all chickens there is lots of Docker commands performing from the Visual Studio.

In the next video we will examine these Docker commands where and how the commands running from the

Visual Studio.
## 2-8 Docker Commands for Shopping.Client Microservice
**Duration: 15 minutes**
In this video, we are going to see Docker commands and run Docker commands for our shopping client

microservices.

Last video we have run debug and stopped Docker container with using Visual Studio tooling, but it

is good to know underlining commands which Visual Studio run behind of us.

Let's take an action.

First of all, let me show you another way to Docker build approach.

You can see the Docker file in here.

It is generated from the Visual Studio, and when I click the Docker file, right click the Docker file

and you can see the Build Docker image button.

Let me click the Build Docker image and follow the logs.

As you can see, that it is running some of the Docker commands.

For us.

And basically it is building an image from this dockerfile right?

As you can find the Docker build command in here and these steps are applying the Docker file commands

one by one.

So this is basically building the Docker file with running Docker build command.

You can find in here and it is getting necessary images.

If not exist, it is retrieving again.

But this time we have already downloaded before and that's why it is a little bit faster from the first

time.

Yes, the build is succeed.

And rebuild, all succeed, as you can see that.

So this is another way to building Docker images.

Also, we already see that run Docker image on Visual Studio and debug it.

Let me show you again.

We put the debugger on controller class and when you click the Docker running profile, it is building

and running image and you can also debug inside of the Docker image.

It is very powerful feature.

You can develop and containerize at the same time and easy to shipping your image.

Write your code and push your image to the your deployment cycle.

As you can see that we see in the our.

Open client container and images and debug is came here.

We can inspect our objects and once we hit the F5 we see the project is running.

And I would like to show you another command from the Visual Studio tooling.

When Visual Studio Docker image is created.

If we clean the project, let me right click and clean the solution.

These.

Let me stop debugging.

Okay.

Uh, this will clean.

Also the commits.

You can see the the remove command.

Right.

So these kind of operations, all of the operations are running from the Visual Studio, but behind

of that it is running the Docker commands.

Right.

So what behind of all these operations, all steps are running one particular Docker command.

So let's see underlying Docker commands and also we can run that commands.

So for that purpose, select the project folder and right click in here.

There is another good base practice and you can see the open in terminal.

I am opening terminal in the my project path.

This is the PowerShell.

Let me see.

It's loading.

Okay, Very good.

So we can start with the basic Docker commands.

Let me show you.

One of the local commands, which is the Docker image.

We can see the building images.

Yes, as you can see that we have a ASP.Net Core image and we have Dotnet SDK image and also we have

two shopping client image, one for development environment, one for latest tech.

Okay.

So actually the latest tech should not be in here.

Let me remove this tech and show you how it is creating.

I'm removing these latest tech image.

Okay, It is deleted.

Let me show you again the limits.

Okay.

Normally when you run the Docker profile, it is basically creating an image with the tag name is the

development environment, right?

So if we would like to shipping these images, these tags should be the latest or the version number.

So in order to perform this operation, make the Visual Studio a run profile to release.

And it is running profile also should be the docker.

And when I run this Docker profile with release mode, it is building the image for me, but this time

it will be created.

Latest Tech.

So that means we are using this release mode when we are shipping our application to the deployment

cycle.

So it is I think we did succeed.

And also our application is running in release mode.

Okay.

Let me close now and open my.

Terminal again.

Okay, so this time, let's check the image.

Now we can see the latest tech came from the release mode, right?

It is another way of the good features when we are using Visual Studio to do operations.

But all these operations handled by the Docker commands, we will see one by one.

So let me continue with the Docker commands.

So now we have two images, one for development environment, one for the latest tech could be shipment

for the deployment, ready for the deployment image.

And now we can also do the manually these building operations.

So let me remove these items and see again we can remove these Docker RMI.

I'm giving the image name.

It is still running on old.

It cannot be forced.

Let me first.

I think it is still running on behind of that.

It is important for us for now.

Let me remove another one.

Okay.

Let's see.

Docker images.

Okay.

I removed one image, but it doesn't import it.

We are creating a new name so you can check the docker running containers with the docker PS.

Yes, as you can see, that the shopping client is still running.

So that's why I think it is not allowing the removing the image.

So let me stop first running Image Docker.

Stop.

I'm giving the container ID.

Okay, it is stopped now.

There is no running container on my local docker.

So let me see the.

Waiting containers.

Also we can remove in here Docker PS all commands.

Okay now we have not running container and also we are not waiting any container ready for running.

So when I check the Docker images we can now able to remove.

Uh, our shopping light.

Right.

Okay.

Yes.

Now my docker image is deleted successfully.

Yes, as you can see that we have not any shopping related image, as we explained before, Docker images.

Uh, let me show you images creates we can create a container from the image.

So.

When we are building an image, we should run this image.

When we run this image, it is basically creating a container.

You can see the this architecture or this relation with from our explanations.

But now we can remove one by one from the container.

And also we are removing the the whole image from our local computer.

So what we can how we can provide this local building operations with Docker commands.

For that purpose, we should be in the same location with the Docker file.

So if we look at the our location, it is the same with our Docker file.

Docker file is inside of the our shopping client.

So I am already in the Docker file pet right?

So in this pet I can write Docker build.

And give the name of the image coping API and I'm putting the dot.

That means in this pet we have a dockerfile.

Please build that docker file for me.

Hit enter and see what's happened.

So as you can see that it is one by one reading our Docker file and performing these commands into the

docker of my local computer.

So it is I think it's a problem for me.

It's most probably with the copy operation.

Yes.

In some cases we should provide the Docker build path, but this time we cannot provide.

But you got the idea when we are running the Docker build command inside of the Docker file path, it

will basically try to building these image from the Docker file.

And also we can run these creating when we create the image, we can run this image with the Docker

run command.

So this time we are not able to build the image with the build command because the path is not correct.

It is arranging by the Visual Studio.

So that's why.

Let me run again.

Let me right click and build Docker image.

Okay, let's copy this line of code and see what is running Docker build.

And there is a okay, as you can see that it is providing the Docker file location, the exact location.

So that's why we can able to boot.

We can not able to boot with this command.

We should provide the Docker file location and as you can see that it is giving the name and performing

the label operations and so on.

I'm not proceed this command because it is already proceed for me from Visual Studio.

I'm now directly check the Docker image and see what's happened.

Let me see the image.

Yes, basically we just do creates image for me.

And let me see the running Docker containers.

Yes, there is no container now.

So in order to run this image with the container, so we should write Docker run command and I'm going

to provide the port number.

Let me this time give me the port number 8080 and I am providing the name parameter for my application.

Let me give my app.

And of course we should provide the image name.

The image name is popping.

Client.

So I am taking the image name from here and basically I'm running the Docker run command and specifying

the port.

Let's hit enter and see what's going on.

Yes, as you can see that the create a container for us and run this container for me.

When I hit the curb, I saw that my shopping client container is running with the 88 port.

So once I.

See the.

He hit the localhost 880.

You can see the our Docker image running in our container.

So basically what I would like to explain that all these operations handled by the Docker commands basically,

but Visual Studio has very great, powerful integration with the Docker.

So you can also use the these two link experience.

But it is good to know underlying Docker commands behind all us with following the output windows and

other stuff.

So let me explain the other basic commands.

You can run the close and you can write the docker and see the all commands.

Yes, the all commands explains very well in here.

So what we are going to mostly in our course we are using the Docker run and we also can be using the

start.

It is basically starting to stop containers and we already using the Docker stop for stopping the containers.

And mostly we are using the pool because we are pulling an image from the Docker hub registry.

And also we are going to push the Docker image to the Docker hub and also other container registry.

So as you can see that we have the Docker commands which we can manage our Docker containers.

So in the next video we are mostly talking about the Docker hub.
## 2-9 Docker Hub Container Registry for Shopping.Client Microservice
**Duration: 4 minutes**
In this video, we are going to see the GitHub container registry and register to Docker for pushing

our image to the crop.

So what is the registry?

It is an environment where the inmates are kept and distributed.

Just like a GitHub.

We can push the images we have to Docker registry or we can pull a Docker image that was previously

loaded into the local area.

In this way we can access an image that will meet your needs very quickly and change it if necessary

and resend it as a different version by giving a new tag name in Docker registry, the desired image

can be pulled locally with the Docker image, pull, image, name command, or you can container process

started from a relevant image by running the docker container run image name to build container.

So which companies provide the ready registry environments?

The first one is the Docker Hub Registry.

There is one limitation for private applications.

Public is unlimited.

And the second one is the Azure Container Registry.

Also, we will use this Azure container registry during the course.

Also there is a container registry and Google container registries.

So let's take an action, first of all.

There is another way to see in the Docker hub.

Let me show you in the application.

So this is the Hub.docker.com.

You can see this like a marketplaces.

First of all, you should log in the Docker hub.

If you have no user, please register and create a subscription for you.

It is free.

You can see the official repositories in here, for example, PostgreSQL, MySQL, Python, ASP.Net

Core and so on.

You can search with the official repositories.

For example, for Mongo official image, it is enough to use the carpool mongo command.

You can see the details in here, description sites in which ports it is exposing, also in which configurations

could be applying.

We will see with the next sections for that mongo image.

So once you have logging the Docker hub, you can search the official image like that and also you can

create your own repository.

So let me go my page and click the repositories.

You can see that I have no any repository yet, so let's create a new repository together.

We can give the name swapping app and you can provide the description.

We will use the public repository for now, but it is allowed only one private repository.

If you use the Azure Container Registry, it is allowed one more private repository to store in their

environment.

So I'm not going to apply any settings and let's just create a repository on the Docker hub.

So as you can see that we have created a shopping app repository and we will push our image into this

repository.

We will use this naming convention.

And as you can see, that the car store our images with the tag numbers into their own hub.

And we will also push our shopping client application into this repository with the next video.
## 2-10 Push Docker Hub Container Registry to Shopping.Client Microservice Docker Image
**Duration: 9 minutes**
In this video, we are going to push the GitHub container registry to shopping client microservice Docker

image.

Let's take an action.

First of all, let me open terminal on Visual Studio.

Let me.

Go back to Visual Studio.

I'm going to right click the project and click to Open in Terminal.

This page should be the same page with the cur file.

It is good to use the same page with the docker file when you performing Docker operations.

I would like to use inline terminal instead of open a new command window.

You can also use the command window for that for that operations because Docker is working in a command

line tool.

But I would like to use the PowerShell from the inside of the Visual Studio.

We will follow the all operations in the one window.

And, uh, it is good to use in on the same page with the Docker file and the development environment.

So after that, the first operation should be the login, the docker within command line, because once

we created the, the corrupt repository, we are providing the login before that.

So that's why it's the same way we can login the Docker.

The command is Docker login.

This will ask us to username and password.

I was providing before.

That's why it is direct login success for me.

You can also login your docker environment with providing the username and password.

So.

After login the docker.

Uh, we should take the Docker image before pushing the any image to the Docker hub.

The image should have the tag name and we should take the image.

It is a mandatory step to applying tag for image that will be pushed to the curb or any container registry.

The image should have the tag name, which tag name should be matched.

The GitHub repository name.

So before we start, we should have the latest tag of the image.

So we are going to take from the latest latest one, not the development one.

This means ready for the production deployment text.

So let's check the existing image and if there is any latest tag.

Yes.

So as you can see that we already run the release mode in the last time and it is selecting it is indicating

the creating the image with the latest tag.

So this image is now ready for the production deployment and pushing any container registry.

So if there is no any latest tech shopping client application you can create with running with the release

mode on Docker run profile.

Otherwise you can also make it manually with the Docker build command.

Let me change it debugged in.

Don't forget about that.

Okay, so once we have the latest client image and we should take the latest one with the Docker repository

name.

So what I'm meaning that we have created the Docker hub image name.

So we also take this.

Latest image with the GitHub repository name Docker take and we should provide the image name.

Nine C7.

I'm only giving the first three keyword.

And also let me paste.

My reporter surname from the crop.

So this will be create a new take from this shopping client image.

Let hit the enter and see what's happened.

Okay.

It is performed.

So as you can see that we give the exact name with the Docker hub repository profile, it cannot match.

Then it should be match when we are pushing the Docker image.

So it's very important.

Let me check now Docker image.

Okay.

Yes.

We have another image name, which is the metal square slash shopping app and exactly same name with

our Docker hub.

So it is successful ticket.

Now it is time to push our image to the Docker hub.

In order to push the Docker image, we will use the Docker Push Command Docker.

Push.

Let me.

Right again.

The curb push.

And we need to provide the image name.

Image name is.

Shopping app.

And of course, we should provide the.

Take name.

It is not necessary, but it is good to use the tag name.

Also when you are pushing your image.

So basically I'm directly providing the image name and running the Docker push command with hit enter.

Yes, the pushing is starting.

It takes some time because we are uploading our image to the Docker hub environment.

When we push the image, the Docker is searching for the tag name and the image name is existing or

not.

If the Docker hub find this image name after that, push the image to the Docker hub.

If not find it is giving an error.

So let's wait for a while for uploading and pushing these local remains to the Docker hub.

And after that, we will check.

This image to the from the docker up.

It takes some time and.

We should check from the Docker hub once the operation is finished.

Since that time.

Let me recap what we have done so far.

We basically adding the Docker file with right click add Docker support in our ASP.Net project.

After that, we are running with the Docker run profile, so it is building and creating Docker image

for us with using this Docker file.

And of course when we run the Docker profile, it is also running image with creating a new container

for us.

So after that we are taking our latest.

A image.

Of course, when we get the latest tech, we are changing the release mode and run the Docker profile.

After that, we have got the latest tech of image and and we also creating a Docker hub repository,

new repository.

And of course we have to take our existing image with the Grub Repository name.

Once we have the Docker hub repository name image, we can able to push our image to the Docker up using

the Docker push command.

And when we push to our image, it is taking some time and after that we will check the Docker hub.

It is successfully pushing or not.

So it is almost done.

Yes, it is pushed.

Let's check our application and refresh our page.

Let me refresh again.

Yes, As you can see, that last pushed a few seconds ago.

And we can see the our latest tech inside of the Docker hub registry.

As you can see that we have pushed the our shopping light image to the Docker hub successfully.

All these steps could be automated with the pipeline development.

We will see it later.
# 第3節：Deploy Shopping.Client Microservice to Azure App Services - Web App for Container
**Total: 6 lectures | 22 minutes**

## 3-1 Introduction
**Duration: 1 minute**
In this section we are going to Deploy Shopping.Client Microservice to Azure App Services

which is the Web App for Containers.

Let's check our big picture and see what we are going to build one by one.

So as you can see that, we are in here and finished to development of Shopping MVC Web Application project.

Project.

And we added container support with DockerFile, push docker images to Docker hub and

now its time to deploy "Azure Web App for Container" resources for 1 web application.

You can see the image that explain our steps, we had Dockerfile and this time we will push docker images

to Docker hub not Azure Container Registry (ACR)

after that we deploy to "Azure Web App for Container".

So after we have learned the basics, we can start with the coding part.
## 3-2 Start with an Azure Free Trial Subscription and Check Azure Portal
**Duration: 3 minutes**
In this video.

We are going to start with an Azure free trial subscription and check the Azure portal.

So what is the Azure account to create or work with the Azure subscription?

You must have an Azure account for Azure account.

You can create a subscription by using the Microsoft account, which is trusted with the Azure Active

Directory.

You can start with the Azure Free Trial Services.

It is giving 200 is a startup package.

So you should follow the steps with creating Azure free account and click the start free.

I have already finished these steps and created the free account for me and linked in the my Microsoft

Mail.

And please follow the these steps and create for your Azure free account.

We will follow other course other videos with using your free account.

Also, I'm going to use my free account.

So let's see the Azure portal.

As you can see that I have logged and when I click the portal portal.azure.com.

You will see the Azure dashboard in here.

You will see Dashboard and you can see the all the resources.

We can check the what options we have for deploying containers.

So let's click the create a resources.

And I am going to click the containers because we have the image container now.

So once I click the containers, it is providing me to list of the available available deploying objects

in here.

So let me close this one.

And.

As you can see that we have container instance container registries, Kubernetes services and webapp

for containers and so on.

Right.

So we will follow one by one.

And let me explain this Kubernetes service.

We will see it in the next videos and container registries.

This is the Azure Container Registry.

Also, we will see and use this Azure container registries with the with the next videos.

And this is what we are going to do.

Web application for the containers.

This is the application service for web containers.

So we are going to follow these web app for containers.

And as you can see that.

Let me start.

Okay.

As you can see, that Azure has great resources that we can use the free trial subscription.

I have created this subscription for testing purpose.

So once you watch these courses, this subscription will be gone.

That's why I can share the portal and other stuff.

So in the next video we are going to create web application for containers.
## 3-3 Create Azure Web App for Containers - App Services for Web apps container
**Duration: 6 minutes**
In this video, we are going to create Azure Web app for containers for deploying our shopping client

application.

So let's take an action first.

Check what options we have for deploying containers.

Click the Create a resources and select the containers.

See the Our options.

We are going to follow web application for containers.

You can see the documentation in here.

The whole documentation explaining how we can use these application services for deploying our applications.

Let me create a web app for containers.

So our resource group is not exist.

So we are going to create Neve which name is.

Pink up.

Okay.

So the name could be the.

Hoping.

EP also.

Or we can say that shopping web this time Resource group is the name.

It is better to use different app name, so not available.

Okay, so let's say shopping app web.

Okay.

So let me continue our configuration.

We are using the Docker container and the region is the nearest one for me.

West Europe.

You can arrange for your location.

And I'm not going to change other stuff for now.

Could the next.

So we are going to using the single container.

And the image source should be the Docker hub because we pushed our image to the Docker hub.

And yes, it is a public image and the image and the tag name is.

Let me write.

Shopping app.

Okay.

Let me verify that.

Yes, this is our application.

You can write the latest tech or not, it is not mandatory.

That's why I'm not providing the tech name now.

And also you will continue the next.

And I'm not going to change anything with the other configurations.

So just hit review and create button.

Okay, let me create the.

My application.

Deployment is progress.

So basically what I have expected that.

The Azure Azure Web app will be retrieve my image from the Docker hub and deploying my image into the

container with the Azure resources.

And this is the basic deployment process for single container.

First time.

It takes some time.

Yes, the deployment is complete.

Very good.

Go to resources.

So now I am inside of the our application deploying application.

And as you can see, the URL once you click the URL.

Let's see what happened.

The first time in the deployment and retrieving the Web application.

It takes some time.

So it is very easy to deploying single container with using other resources.

Let's wait for the light.

So as you can see that you can.

Examined these deployment tops and other settings.

This is the application service.

Resources in the Azure.

So we basically have a one container and pushing to the docker up and we set the other creating the

app service and please, uh, deploying a container and retrieve container from the Docker hub.

And it is creating successfully.

So that means Azure deploying our container into the app service.

And yes, finally, as you can see that, uh, we can see the, our application, this is now on production

live.

And uh, once we commit the code from the Visual Studio, it is basically.

Push the R codes into GitHub repository and Docker up, identify with the webhook and start building

with the continuous integration.

Once the image is built in here and Azure captured the this Docker hub image and deploying the application.

So this is the one single container deployment process.

What we have done so far.

We can manage to deploying container to Azure successfully.

Next time we will automate this process with the multi container application microservices.
## 3-4 Examine Azure Web App for Containers - App Services for Web apps container
**Duration: 3 minutes**
In this video, we are going to examine Azure Web application from the Azure Portal, see the Azure

portal in here.

So we have created the app service plan in the last video.

So let me open this app service plan.

So as you can see that we have a URL information.

Once we click the URL information, you can see the our application is live on production and see other

configurations in here.

These are the some configuration tops we can identify one by one, for example, uh, activity logs,

access controls, tags and so on.

So there is also deployment options for our we are using the deploying container from the Docker hub.

So for that purpose you can check the container settings.

So please see the container settings and identify that image source from the Docker hub.

So in the other way we can pull the image sources from the other container registries we will see in

the next videos.

And also if you have private registry, you can use the private registries and repository access is

public for us because we are publishing into the group with public repository.

But if you choose the Azure Container Registry, you can set the private repository access.

Also you identify that full name of image and take these places.

We are exact the same name with the crop and it should be very important with the crop because Azure

container images retrieving pulling the image from Docker hub with this name information.

This is the global unique name.

And also you can see the continuous deployment is off now, but we can set the on for the CI CD pipelines.

We will do it later and you can see the logs in here, as you can see that pulling from the Docker hub.

Images and the other information locks you can see in here.

So basically, Azure have a great dashboard and there's lots of options in here.

For example, scale up and scale out functions if you would like to.

Scale your application in one container.

You can use these configurations.

So let's have a look for the Azure dashboard settings.

And in the next video we are going to try to make CI CD operations for a single container.
## 3-5 CI/CD for Single Container - Continuous Deployment on Azure Web App for Container
**Duration: 8 minutes**
In this video, we are going to see how to make CI CD pipeline for single container continuous deployment

on Azure Web app for containers.

So let's take an action.

First of all, we should check for the CI continuous integration, build part of our application.

This is the CI part.

When we push to code on GitHub, it should trigger the Docker build and push the image to the crop.

So let's check the Docker up.

As you can see that we have a width sections.

And in the U.S., we have already configured our build operation with the latest tech and giving the

main main branch ID and build operation.

And we set the auto build operations right.

But in the last build, it has some error.

I'm not going to details, but I would explain later.

But it is important to arrange all these automated builds with Docker up.

Okay.

So this is continuous integration part, right?

So once we check in the our codes to the GitHub, it will trigger the Docker up and Docker up with Docker

image again and set the latest image with the new version.

And after that we can say that we should set the CD part.

That means continue this deployment on Azure web app for containers.

So for that purpose, go to Azure portal and open open the our web app for containers.

And go to our container settings.

So maybe you remember we were talking about the continuous deployment.

So set on these parameters.

And when we set on this parameter, we have a webhook URL.

Let me say first.

Okay.

I'm going to show you as well.

As you can see that we have a webhook URL that provide to hook the Azure for deployment the image.

So I'm copy this webhook URL and we are going to paste these webhook URL to the crop.

So in the crop, open the repository again and see that you we have a webhook section in the repository.

Right?

So open the webhook section and give the name.

As.

And paste this webhook in here.

So basically what we have done with the webhooks, if there is a webhook in the Docker hub repository,

once the repository changes the image it is triggered.

These webhooks and these webhooks indicate the Azure web app for containers and it is automatically

start with the pulling image from scratch and deploying our single container into the Azure Web application

resources.

So let me test our application.

Now let me change some code and push to GitHub.

We assume that the group identified the GitHub and built the image with the latest from the latest code

and add the docker up with a new tag.

After that trigger the Azure webhook that will retrieve the image from Docker hub from scratch and deploy

the image into the Azure web app for container services.

These all operations will be automated, so that means including the CI and CD part for single container.

So let me open our code.

Close this one.

Go to the my index page views.

Index page.

And in the.

Product section.

Yes.

Let me put any comments for the single containers.

Let's save the application.

So I'm going to push this code single.

Containers.

Edit.

I'm going to commit and sync with the GitHub.

Once GitHub pushed the codes, the Docker up, identified the new code chains and try to build the Docker

image with the newly added code.

Yes, single container.

Edit.

Now we will see in here.

Yes, as you can see that another build is started from the new code changes.

So this build is trying to create a new image from the Docker file and with the new code changes.

And after the build finished it is triggering the webhooks and call this address.

And once this address called the Azure Web app resources pulling image from the crop from the beginning

and deploying our image into the production.

And we will see the description into the here.

Okay.

This is the single container CI CD pipeline.

So let me show you now in the build section.

So these are second field.

It is going to preparing now.

So let me show another bullet, which is the failed because this will also is going to be failed.

So as you can see that even I provide the Docker file path is correct.

So somehow in copy commands it cannot be identified.

Copy failed from the docker image.

No such file or directory.

I'm fixing this problem from the Azure pipelines with giving the world context, which is a Docker file

and most probably we are going to change our docker file with the copy copy patch according to this

patch, because normally the Docker file should be in the root application root folder structure.

But ASP.Net put this Docker file under the project structure.

So that's why it's getting some confusing.

But we would solve this problem with giving the build context into other pipelines we will solve in

the last section.

So that's why I'm not going to proceed now.

But you got the idea we can able to perform CI CD operation with a single container with using GitHub.

When pushing to GitHub it is tricking to the GitHub and the corrupt trying to build and create a new

image with the latest tech.

And once we provide the webhook to Docker, Docker up performing the operations after the build, it

is triggering this URL and once other triggering with this URL, Azure will be pulling the image with

the latest tech and from the secret from the beginning and deploying our application from scratch.

And we can able to access new codes with changing the index page.

So this is the single container CI CD pipeline.

In the next section we are going to develop multi container microservice and we are going to deploy

these services with using the Kubernetes and automation.
## 3-6 Delete Azure Resource - Azure Web App for Containers
**Duration: 1 minute**
In this video, we are going to delete Azure Resources Azure Web app for containers.

It is important to delete, delete and release unused resources on your subscription in order to avoid

high paying bills.

So let's take an action.

Go to Azure portal and this time I'm going to delete directly Resource Group.

This is the route object.

So once I delete this resource group, this will affect all of the items.

Delete the resource group.

So it is expecting the writing resource group name.

So I'm clicking the delete.

Yes, it is deleting.

So basically it is takes a few minutes to reflect in our portal, but make sure that you delete your

resources when you don't use into Azure.

In the next section.

We are going to developing the shopping API microservices and composing microservices with Docker Compose

and moving to Kubernetes.
# 第4節：Developing Shopping.API Microservice with MongoDb and Compose All Docker Container
**Total: 6 lectures | 22 minutes**

## 4-1 Introduction
**Duration: 1 minute**

## 4-2 Create Asp.Net Core Web API Project For Shopping.API Microservice
**Duration: 2 minutes**

## 4-3 Create Product Controller Class for Shopping.API Microservice
**Duration: 4 minutes**

## 4-4 Add Data Folder and Refactor ProductContext for Shopping.API Microservice
**Duration: 3 minutes**

## 4-5 Set Launch Settings and Port Numbers Defined for Shopping Microservices
**Duration: 3 minutes**

## 4-6 Consume Shopping.API from Shopping.Client Microservices with using HttpClientFactory
**Duration: 8 minutes**

# 第5節：Setup Mongo Docker Database
**Total: 6 lectures | 30 minutes**

## 5-1 Introduction
**Duration: 1 minute**

## 5-2 Setup Mongo Docker Database for Shopping.API Microservices
**Duration: 9 minutes**

## 5-3 Interactive Terminal For MongoDb Connection
**Duration: 5 minutes**

## 5-4 Connect Mongo Docker Container from Shopping.API Microservice
**Duration: 4 minutes**

## 5-5 Connect Mongo Docker Container from Shopping.API Microservice Part 2
**Duration: 8 minutes**

## 5-6 Test All Microservices - Shopping.Client - Shopping.API - MongoDb
**Duration: 3 minutes**

# 第6節：Containerize Microservices with Creating Multi-Container App using Docker Compose
**Total: 6 lectures | 45 minutes**

## 6-1 Introduction
**Duration: 2 minutes**

## 6-2 Adding Docker-Compose File for Shopping Microservices Solution
**Duration: 5 minutes**

## 6-3 Adding MongoDb into Docker-Compose File
**Duration: 4 minutes**

## 6-4 Run multi-container application with Docker Compose
**Duration: 10 minutes**

## 6-5 Exception Fixes on Running Docker Compose
**Duration: 21 minutes**

## 6-6 Recap Docker Commands
**Duration: 5 minutes**

# 第7節：Introduction to Kubernetes
**Total: 15 lectures | 1 hour 9 minutes**

## 7-1 Introduction
**Duration: 1 minute**

## 7-2 What is Kubernetes ?
**Duration: 1 minute**

## 7-3 Kubernetes Architecture
**Duration: 2 minutes**

## 7-4 Kubernetes Components
**Duration: 3 minutes**

## 7-5 Local Kubernetes Installment
**Duration: 5 minutes**

## 7-6 kubectl Commands
**Duration: 7 minutes**

## 7-7 Declarative vs Imperative
**Duration: 2 minutes**

## 7-8 Creating Pods on Kubernetes
**Duration: 5 minutes**

## 7-9 Creating Deployment on Kubernetes
**Duration: 6 minutes**

## 7-10 Troubleshooting on Kubernetes
**Duration: 7 minutes**

## 7-11 Declarative Way Kubernetes - Running yaml Files
**Duration: 6 minutes**

## 7-12 Testing Declarative Way Kubernetes - testing yaml Files
**Duration: 6 minutes**

## 7-13 Creating Service on Kubernetes and More About yamls
**Duration: 14 minutes**

## 7-14 Deploying Kubernetes WebUI Dashboard
**Duration: 7 minutes**

## 7-15 Kubernetes Quiz
**Quiz**

# 第8節：Deploying Microservices on Kubernetes
**Total: 17 lectures | 1 hour 24 minutes**

## 8-1 Introduction
**Duration: 1 minute**

## 8-2 Planning to Shopping Microservices yaml files
**Duration: 2 minutes**

## 8-3 Visual Studio Code Setup
**Duration: 5 minutes**

## 8-4 Create Mongo Db Deployment yaml File
**Duration: 5 minutes**

## 8-5 Create Secret For Mongo Db Admin Root Username and Password
**Duration: 4 minutes**

## 8-6 Use K8s Secret Values in Mongo Deployment yaml file
**Duration: 3 minutes**

## 8-7 Create K8s Service Definitions for Mongo Db
**Duration: 4 minutes**

## 8-8 Build Shopping Docker Images , Tag and Push to Docker Hub
**Duration: 6 minutes**

## 8-9 Build Shopping Docker Images, Tag and Push to Docker Hub Part 2
**Duration: 7 minutes**

## 8-10 Clearing Docker Compose Containers
**Duration: 3 minutes**

## 8-11 Create Shopping.API k8s Deployment and Service yaml File
**Duration: 7 minutes**

## 8-12 Testing Shopping.API yaml file on k8s
**Duration: 6 minutes**

## 8-13 Move Connection String into Config Map yaml file on k8s
**Duration: 5 minutes**

## 8-14 Create Shopping.Client K8s Deployment and Service yaml File
**Duration: 5 minutes**

## 8-15 Create Shopping.Client K8s Deployment and Service yaml File Part 2
**Duration: 6 minutes**

## 8-16 Troubleshooting on K8s For Shopping.Client K8s yaml File Definitions
**Duration: 12 minutes**

## 8-17 Clear and Create All K8s Resources on Your Docker Cluster
**Duration: 3 minutes**

# 第9節：Deploy Shopping Microservices into Cloud Azure Kubernetes Service with using ACR
**Total: 20 lectures | 2 hours 12 minutes**

## 9-1 Introduction
**Duration: 1 minute**

## 9-2 Azure Container Registry (ACR)
**Duration: 2 minutes**

## 9-3 Azure Kubernetes Service (AKS)
**Duration: 2 minutes**

## 9-4 Steps to the AKS Deployment
**Duration: 3 minutes**

## 9-5 Prepare Shopping Microservices for Azure Kubernetes Service (AKS)
**Duration: 11 minutes**

## 9-6 Deploy and use Azure Container Registry
**Duration: 15 minutes**

## 9-7 Deploy and use Azure Container Registry Part 2
**Duration: 11 minutes**

## 9-8 Deploy an Azure Kubernetes Service (AKS) cluster
**Duration: 5 minutes**

## 9-9 Deploy an Azure Kubernetes Service (AKS) cluster Part 2
**Duration: 7 minutes**

## 9-10 Run applications in Azure Kubernetes Service (AKS)
**Duration: 5 minutes**

## 9-11 Create Image Pull Secret for ACR Container
**Duration: 5 minutes**

## 9-12 Edit K8s Manifest Yaml Files For Deploying AKS
**Duration: 10 minutes**

## 9-13 Run K8s Manifest Yaml Files For Deploying AKS
**Duration: 9 minutes**

## 9-14 Scale Shopping applications in Azure Kubernetes Service (AKS)
**Duration: 11 minutes**

## 9-15 Autoscale Shopping Pods in Azure Kubernetes Service (AKS)
**Duration: 8 minutes**

## 9-16 Update Shopping Microservices With Zero-Downtime Deployment on Live AKS
**Duration: 9 minutes**

## 9-17 Tag and Push the New Version of Shopping.Client Image to ACR
**Duration: 5 minutes**

## 9-18 Deploy v2 of Shopping.Client Microservices to AKS with zero-downtime rollout k8s
**Duration: 7 minutes**

## 9-19 Update CPU Resources for Zero-Downtime Deployments
**Duration: 9 minutes**

## 9-20 AKS-ACR Quiz
**Quiz**

# 第10節：Automate Deployments with CI/CD pipelines on Azure DevOps
**Total: 20 lectures | 2 hours 26 minutes**

## 10-1 Introduction
**Duration: 1 minute**

## 10-2 Introduction to Azure DevOps
**Duration: 2 minutes**

## 10-3 Introduction to Azure Pipelines
**Duration: 2 minutes**

## 10-4 Deploy to AKS through Azure CI/CD Pipelines
**Duration: 3 minutes**

## 10-5 Sign up for Azure Pipelines
**Duration: 5 minutes**

## 10-6 Create Our first pipeline with Azure Pipelines
**Duration: 7 minutes**

## 10-7 Pipeline Docker Task Yaml File Explained in Azure Pipelines
**Duration: 11 minutes**

## 10-8 Pipeline Docker Task Error Fixed in Azure Pipelines
**Duration: 17 minutes**

## 10-9 Pipeline Tasks and How to Decide to Write Correct Task in Azure Pipelines
**Duration: 4 minutes**

## 10-10 Create Pipeline for Continues Delivery with Deploy to AKS Task
**Duration: 6 minutes**

## 10-11 Create Pipeline for Continues Delivery with Deploy to AKS Task Part 2
**Duration: 9 minutes**

## 10-12 Refactoring Our Pipeline for Continues Delivery with Deploy to AKS
**Duration: 8 minutes**

## 10-13 Running Pipeline for Continues Delivery with Deploy to AKS
**Duration: 6 minutes**

## 10-14 Manage Pipelines for Multi-Container Microservices with CI/CD flows in Azure Pipelines
**Duration: 11 minutes**

## 10-15 Create New Pipeline For ShoppingAPI Microservices with existing pipeline yaml file
**Duration: 11 minutes**

## 10-16 Create New Pipeline For Shopping.Client Microservices
**Duration: 8 minutes**

## 10-17 Create New Pipeline For Shopping.Client Microservices Part 2
**Duration: 19 minutes**

## 10-18 Rename Pipeline and Test Trigger Shopping Pipelines
**Duration: 8 minutes**

## 10-19 Put Azure Pipeline Status Badge into Your Github Project
**Duration: 4 minutes**

## 10-20 Clean All AKS and Azure Resources
**Duration: 4 minutes**

# 第11節：Automate Existing Microservices Reference Application with AKS and Azure DevOps
**Total: 1 lecture | 2 minutes**

## 11-1 Introduction
**Duration: 2 minutes**

# 第12節：Thanks
**Total: 1 lecture | 1 minute**

## 12-1 Bonus Lecture
**Duration: 1 minute**

