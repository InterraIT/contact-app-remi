# Contacts Management Application

This is a simple Contacts Management Application built with Angular 15.0.4 and .NET Core 6.0.

## Setup Instructions

### Prerequisites

Before you begin, ensure you have the following tools installed:

- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)
- [.NET Core SDK](https://dotnet.microsoft.com/download)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/ContactsManagementApplication.git
   ```

2. Navigate to the project root directory:

   ```bash
   cd ContactsManagementApplication
   ```

3. Install npm packages for the Angular app:

   ```bash
   cd ContactsApp
   npm install
   ```

4. Restore NuGet packages for the .NET Core app:

   ```bash
   cd ..
   dotnet restore
   ```

## How to Run the Application

### Angular App

1. Navigate to the `ContactsApp` directory:

   ```bash
   cd ContactsApp
   ```

2. Run the Angular development server:

   ```bash
   ng serve
   ```

3. Open your browser and navigate to `http://localhost:4200/` to access the Angular app.

### .NET Core App

1. Navigate to the project root directory:

   ```bash
   cd ContactsManagementApplication
   ```

2. Run the .NET Core application:

   ```bash
   dotnet run
   ```

3. Open your browser and navigate to `http://localhost:7052/` to access the .NET Core API.

## Design Decisions and Application Structure

### Angular App

- The Angular app follows a modular structure with separate components for different features like listing contacts, adding a contact, updating a contact, etc.
- Angular services are used to encapsulate data retrieval and manipulation logic, promoting code reusability.
- **Bootstrap for Layout Design**: The application leverages Bootstrap for creating a responsive and visually appealing layout, ensuring a consistent and user-friendly design.

- **ng-bootstrap for Popups**: Popups for adding and editing contacts are implemented using ng-bootstrap. This library provides Bootstrap components written in Angular, allowing for easy integration of Bootstrap features into Angular applications. The use of modals enhances the user experience when interacting with contact details.

- **Confirmation Dialog for Delete Operations**: A confirmation dialog is incorporated for delete operations to prevent accidental deletions. This dialog ensures a deliberate action is taken before removing a contact.

- **Reactive Forms with Built-in Validations**: Reactive forms are employed for handling user input in a structured and efficient manner. Angular's reactive forms offer powerful features, including built-in validation capabilities. This ensures that the data entered by users meets the specified criteria, providing a smoother and error-resistant user experience.

### .NET Core App

- The .NET Core app follows a layered architecture with separate folders for controllers, services, repositories, and models.
- Dependency Injection is used to inject services into controllers and repositories.
- Error handling is implemented using a global exception handler middleware to return appropriate error responses.
