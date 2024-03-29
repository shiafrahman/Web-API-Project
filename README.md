# Web-API-Project
Project Overview:
This project comprises two separate applications developed using ASP.NET Core: an ASP.NET Core Web API and an ASP.NET Core MVC application. The Web API serves as the backend, providing endpoints for CRUD operations on department and student data. The MVC application consumes these APIs to display and manage the data through a user-friendly interface.

Folder Structure:

API: Contains the ASP.NET Core Web API project.

MVC: Houses the ASP.NET Core MVC application project.

API (ASP.NET Core Web API):

Controllers: Contains controllers responsible for handling HTTP requests and generating responses. These controllers manage endpoints for CRUD operations on department and student data.

Models: Houses model classes representing department and student entities.

Services: Holds service classes responsible for interacting with the database and implementing business logic.

Migrations: Stores database migration files generated by Entity Framework Core for managing database schema changes.

appsettings.json: Configuration file containing settings for the application, such as database connection strings.
MVC (ASP.NET Core MVC):


Controllers: Contains controllers for handling user interactions and invoking API endpoints to fetch or manipulate data.

Views: Contains Razor view files responsible for rendering HTML content to the user.

Models: Houses model classes representing data entities used in the MVC application.


appsettings.json: Configuration file containing settings specific to the MVC application.

Database Integration:

The database schema includes two main tables: TblDepartment and TblStudent.
Each department can have multiple students associated with it, forming a one-to-many relationship between departments and students.
A trigger is implemented in the TblStudent table to update the TotalStudent count in the corresponding department whenever a new student is added or removed.

User Interface:


The MVC application provides user interfaces for creating, reading, updating, and deleting departments and students.
Pop-up dialogs are utilized for creating and editing department and student information, enhancing the user experience.

Setup Instructions:

Clone the repository to your local machine.

Open the solution in Visual Studio.

Ensure that the necessary dependencies are restored.

Update the database connection strings in the appsettings.json files for both projects.

Run the database migrations to apply the schema changes.

Build and run the Web API project to start the backend server.

Build and run the MVC application to launch the user interface.

Additional Notes:


Ensure that both projects are running simultaneously to facilitate communication between the Web API and MVC application.
Make sure to handle any authentication and authorization requirements based on the application's security needs.
Continuously test and refine the application to ensure proper functionality and performance.
