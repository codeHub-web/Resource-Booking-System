# Resource-Booking-System

This is an ASP.NET Core Razor Pages application developed for booking and managing internal resources. It utilises Entity Framework Core to communicate with the database.

## Prerequisites

Before setting up the project, ensure the following are installed:

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- SQL Server / LocalDB 

## How To Get Started
### Clone the repository
 - git clone https://github.com/codeHub-web/Resource-Booking-System

 ### Configure your Database Connection 
 - Navigate to 'appsettings.json' and set up your database connection string
 -Ensure your connection is successful. Confirm by checking 'data connections' on the server explorer on the left hand panel.

 ## Add Entity Framework Core to your packages
 - Right-click on your project name on the solution explorer
 - Go to 'Manage Nuget Packages'
 - Install Microsoft Entity Framework Core

### Apply Entity Framework Core migrations
- On your Visual Studio Console, type: 'Add-Migration', followed by 'Update-database'

## Run the application
- A Window should pop up on your browser
