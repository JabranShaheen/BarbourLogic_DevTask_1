# Library Management System

This project is a simplified library management system implemented in C#. It allows users to perform basic operations such as adding, updating, deleting books, as well as borrowing and returning books.

## Folder Structure 
<img width="496" alt="image" src="https://github.com/JabranShaheen/BarbourLogic_DevTask_1/assets/34131257/de9f766d-e9e1-4231-b77e-05ad175eab30">

Server -> Business logic and Web-API

Clinet -> Angular Project 

## Design
<img width="411" alt="image" src="https://github.com/JabranShaheen/BarbourLogic_DevTask_1/assets/34131257/c94d3f5d-25c5-4fb7-9881-c0056dcd6d55">

#### Repository: 
Manages data access and storage operations, providing CRUD (Create, Read, Update, Delete) functionality for entities.

#### Manager: 
Implements business logic and coordination between repositories and clients, ensuring operations adhere to application rules and constraints.

## Solution Structure 
<img width="309" alt="image" src="https://github.com/JabranShaheen/BarbourLogic_DevTask_1/assets/34131257/25bc93c0-97a9-47c0-b71e-8a9a1b1e2e9d">

### BarbourLogic_DevTask_1.Abstractions:
Contains interfaces defining contracts for entities and repositories used in the library management system.

### BarbourLogic_DevTask_1.Implementations:
Implements concrete repository classes that handle data storage and retrieval for books and users.

### BarbourLogic_DevTask_1.Tests:
Houses unit tests covering CRUD operations, search functionalities, and error handling for the library management system.

### BarbourLogic_DevTask_1.WebAPI:
Provides a web API built with ASP.NET Core to expose endpoints for managing books and users, including search capabilities.

### Server Application Instructions:

-Right-click the WebAPI project and set it as the startup project.

-Run the application. 

<img width="562" alt="image" src="https://github.com/JabranShaheen/BarbourLogic_DevTask_1/assets/34131257/8dc92391-0155-49c0-a743-98ac10296429">

### Client Side instructions (Angular)

- Open Client Angular application in VS Code

<img width="349" alt="image" src="https://github.com/JabranShaheen/BarbourLogic_DevTask_1/assets/34131257/0ec70b83-635a-4b04-95ea-0033ef846776">

- Make sure the API address is correct in bookservice.ts

- <img width="655" alt="image" src="https://github.com/JabranShaheen/BarbourLogic_DevTask_1/assets/34131257/e09f1006-b5ce-4f4a-8c9d-73e0d901f3ef">

- Search Functionality (The search fields can be used in combination and are case insensitive.)

- <img width="561" alt="image" src="https://github.com/JabranShaheen/BarbourLogic_DevTask_1/assets/34131257/4436328b-c80f-45ad-bde5-5f2f68f5b4b6">

### Seed data/initial data

<img width="1055" alt="image" src="https://github.com/JabranShaheen/BarbourLogic_DevTask_1/assets/34131257/4cc912eb-8d99-426b-90c9-0a1e3f001903">

#### Note: 
Ideally, this setup should be performed in the bootstraping project.

#### Principles and patterns applied: 

##### Dependency Inversion Principle (DIP): 
High-level modules (e.g., managers) depend on abstractions (e.g., interfaces), not on concrete implementations (e.g., repositories).
##### Creational Pattern (Singleton):
Singleton pattern is used in middleware to ensure there is only one instance of the middleware class shared across all requests.
##### Separation of Concerns:
Repository: Handles data access and persistence operations.

Manager: Implements business logic and orchestrates interactions between repositories and the application.

#### Further enhancements : 
###### Checkout Process
A "checkout" process as a separate use case, treating BookCheckOut as an aggregate with its own repository and service. This approach would manage the list of checked-out books independently, allowing the User class to remain lightweight without the responsibility of storing checked-out books. This design promotes better separation of concerns and enhances maintainability by encapsulating checkout-related operations within dedicated components.

###### Handling stock 
Handling stock of books as an enhancement involves managing multiple copies of the same book efficiently, ensuring availability and notifying users or administrators about stock levels.
