# Tournament and League Management System

Welcome to the Tournament and League Management System! This project provides an environment for creating and managing tournaments and leagues across multiple sports and esports. The backend is built with .NET Identity, offering robust user authentication and authorization capabilities. Please note that the front-end is currently minimal and features a basic Bootstrap theme.

## Features

- **Multi-Sport Support**: Create and manage tournaments for various sports and esports.
- **User Authentication**: Integrated with .NET Identity for secure user management.
- **Tournament Management**: Features for creating, editing, and deleting tournaments and leagues.
- **Role Management**: Assign roles such as admin, player, and organizer.
- **Flexible Scheduling**: Tools for managing event schedules and updates.

## Technologies Used

- **Backend**: .NET Identity
- **Frontend**: Bootstrap (basic theme applied)
- **Database**: SQL Server
- **Hosting**: Still Localhost

## Requirequirements

To run this project locally, you will need the following:

- **.NET SDK 9**: Recommended use of Visual Studio for easier running and installing required system.
- **SQL Server**: Ensure you have an instance of SQL Server running, either locally or remotely.
- **Git**: For cloning the repository.



## Installation

To get started with the project, follow these steps:

1. **Clone the repository**:
2. Open solution in Visual Studio or other IDE.
3. Run SQL server.
4. Copy your servers name in application.json line 10: "DefaultConnection": "Server="YOUR SERVER NAME"; Database=tHUB; Trusted_Connection=True;TrustServerCertificate=True"
5. In Package maneger console change default project to thub.DataAcess
6. run Update-Database command
7. Change browser setting ex. for chrome: chrome://flags/#allow-insecure-localhost to allow
8. run project
