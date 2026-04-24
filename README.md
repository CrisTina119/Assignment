Assignment - User-ost-Comment (.NET)
This project is a social networking application developed as an assignment for the .NET Programming course. It demonstrates the implementation of a distributed system using C#, Blazor, and Web API, focusing on clean architecture and data management.

Project Overview
The application allows users to interact with a digital platform where they can manage users, create and view posts, and engage through comments. The system is built with a decoupled architecture, ensuring a clear separation between the user interface and the data persistence logic.

Technologies Used
Frontend: Blazor WebAssembly (WASM) for a responsive, interactive client-side experience.

Backend: ASP.NET Core Web API for handling business logic and HTTP requests.

Language: C# (.NET 8.0 / .NET 9.0).

Data Management: * JSON Persistence: Files used for long-term storage (Posts.json, Users.json, comments.json).

In-Memory Storage: Implementations for testing and fast prototyping.

Shared Contracts: A dedicated project for Data Transfer Objects (DTOs) and interfaces to ensure consistency between Client and Server.

Project Structure
Client (BlazorApp): The UI components, pages (Home, Weather, Counter), and services that communicate with the API.

Server (WebAppi & CLI): * WebAppi: The RESTful API controllers.

CLI: A command-line interface for administrative tasks and testing.

Shared (ApiContracts): Shared models and request/response objects.

Infrastructure:

Entities: Core domain models (User, Post, Comment).

FileRepositories: Logic for saving/loading data from JSON files.

InMemoryRepositories: Logic for volatile data storage.

RepositoryContracts: Interfaces defining the data access layer.

Key Features
User Management: Create and list users.

Post Management: Create, view, and list posts from different users.

Commenting System: Add, view, modify, and delete comments associated with specific posts.

Persistence: All data is saved in JSON format, allowing the state to be maintained across application restarts.

How to Run
Clone the repository:

Bash
git clone https://github.com/CrisTina119/Assignment.git
Run the Server: Navigate to the Server/WebAppi folder and run:

Bash
dotnet run
Run the Client: Navigate to the Client/BlazorApp folder and run:

Bash
dotnet run
Open your browser at the URL provided in the terminal (usually http://localhost:5000 or similar).
