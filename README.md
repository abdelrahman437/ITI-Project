# 🎓 **ITI Project – ASP.NET MVC Application**

<p align="center">
  <img src="https://img.shields.io/badge/.NET-6.0-blueviolet?style=for-the-badge" alt=".NET Badge" />
  <img src="https://img.shields.io/badge/License-MIT-green?style=for-the-badge" alt="License Badge" />
  <img src="https://img.shields.io/badge/Contributions-Welcome-brightgreen?style=for-the-badge" alt="Contributions Badge" />
</p>

---

## 🚀 **Overview**

Welcome to the **ITI Project**, a clean, scalable **ASP.NET MVC web application** built with best practices in mind. This solution is structured in three layers (Presentation, Business Logic, Data Access) and uses **Entity Framework Core** to communicate with the database.

> 💡 **Goal:** To showcase enterprise-level architecture using MVC, Repository + Unit of Work pattern, and modular code.

---

## ✨ **Key Features**

* ✅ **CRUD Operations** – Manage Courses, Users, Sessions, and Grades
* ✅ **Repository + Unit of Work** – Clean, testable data access layer
* ✅ **Custom Validation Attributes** – Enforcing data integrity
* ✅ **Pagination Helper** – Optimized for large data sets
* ✅ **Responsive UI** – Razor pages styled with Bootstrap
* ✅ **Modular Architecture** – Easy to maintain and scale

---

## 🛠️ **Prerequisites**

Before running the project, install:

* [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code + C# extension
* [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* SQL Server or a compatible database engine

---

## ⚙️ **Installation & Setup**

```bash
# Clone the repository
git clone https://github.com/abdelrahman437/ITI-Project.git

# Navigate to the folder
cd iti-project

# Restore dependencies
dotnet restore

# Apply EF Core migrations
dotnet ef database update

# Run the project
dotnet run
```

> 🌍 The app will run on **[https://localhost:5001](https://localhost:5001)** (or the port defined in launchSettings.json).

---

## 🗂 **Project Structure**

```
ITI-Project.sln
├── ITI-Project/ (Presentation Layer)
│   ├── Controllers/
│   │   ├── HomeController.cs
│   │   ├── CourseController.cs
│   │   ├── SessionController.cs
│   │   ├── GradeController.cs
│   │   └── UserController.cs
│   ├── Views/
│   │   ├── Shared/_Layout.cshtml, _ValidationScriptsPartial.cshtml, Error.cshtml
│   │   ├── Course/Index.cshtml, Create.cshtml, Edit.cshtml, GetById.cshtml, _CourseForm.cshtml
│   │   ├── Session/Index.cshtml, Create.cshtml, Edit.cshtml, Details.cshtml, _SessionForm.cshtml
│   │   ├── Grade/Index.cshtml, RecordGrade.cshtml
│   │   └── User/Index.cshtml, Create.cshtml, Edit.cshtml, Details.cshtml, _UserForm.cshtml
│   ├── Program.cs, appsettings.json, launchSettings.json
│
├── ITI-Project.BLL/ (Business Logic Layer)
│   ├── Services/ (CourseService.cs, GradeService.cs, SessionService.cs, UserService.cs)
│   │   └── Interfaces/ (ICourseService.cs, IGradeService.cs, ISessionService.cs, IUserService.cs)
│   ├── ViewModel/
│   ├── Helpers/Pagination.cs
│   └── Custom Validation/ (DateGreaterAttribute.cs, FutureDateAttribute.cs, NoNumberAttribute.cs)
│
├── ITI-Project.DAL/ (Data Access Layer)
│   ├── Models/ (Course.cs, Session.cs, User.cs)
│   ├── Repository/
│   │   ├── CourseRepository.cs, GradeRepository.cs, SessionRepository.cs, UserRepository.cs, GenaricRepository.cs, UnitOfWork.cs
│   │   └── Interfaces/ (ICourseRepository.cs, IGradeRepository.cs, ISessionRepository.cs, IUserRepository.cs, IGenaricRepository.cs)
│   ├── Configuration/
│   ├── Migrations/
│   └── AppDbContext.cs
```

---

## 📡 **API Endpoints (Routes)**

| Controller  | Endpoint                | Description          |
| ----------- | ----------------------- | -------------------- |
| **Home**    | `/Home/Index`           | Landing page         |
| **Course**  | `/Course/Index`         | List all courses     |
|             | `/Course/Create`        | Add new course       |
|             | `/Course/Edit/{id}`     | Edit course          |
|             | `/Course/GetById/{id}`  | View course details  |
| **Session** | `/Session/Index`        | List sessions        |
|             | `/Session/Create`       | Create new session   |
|             | `/Session/Edit/{id}`    | Edit session         |
|             | `/Session/Details/{id}` | View session details |
| **Grade**   | `/Grade/Index`          | View all grades      |
|             | `/Grade/RecordGrade`    | Record new grade     |
| **User**    | `/User/Index`           | List users           |
|             | `/User/Create`          | Create new user      |
|             | `/User/Edit/{id}`       | Edit user            |
|             | `/User/Details/{id}`    | View user details    |
