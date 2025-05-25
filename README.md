# Library Management System

This project was developed as part of my coursework for the Windows Programming subject in the Diploma in Information Technology course. It is a desktop application built using C# and .NET, designed to manage library inventory and streamline the borrowing and return process.

## 🛠️ Technologies Used
- C#
- .NET Framework
- Windows Forms
- MySQL Workbench
- Visual Studio 2022

## 🗃️ Database Overview
The project uses a database named `library` with the following tables:

- `books` – Stores books data
- Columns: `id`, `book_title`, `author`, `published_date`, `status`, `date_insert`, `date_update`, `date_delete`, `image`

- `issues` – Stores borrowed books data
- Columns: `id`, `issue_id`, `full_name`, `contact`, `email`, `book_title`, `status`, `return_date`, `date_insert`, `date_update`, `date_delete`

## 🚀 How to Run the Project
### 1. Set up the database
- Open your preferred SQL client.
- Create a new database named `library`.
- Select or switch to the `library` database.  
- Use the **Import** or **Run SQL File** option in your client.  
- Choose the included `library.sql` file from the project directory. 
- Execute the import to create the necessary tables (`books` and `issues`) with all required relationships.

### 2. Configure the application
- Open the project in Visual Studio 2022.
- Update the database connection string in *Database.cs* with your MySQL credentials:

```csharp
// Database.cs
private static string connectionString = "Server=localhost;Database=library;User ID=your_db_username;Password=your_db_password;";
```

### 3. Build and run
- Build the solution.
- Run the application.
