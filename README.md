# 🚚 eShift - Delivery Management System

**eShift** is a C# Windows Forms-based Delivery and Logistics Management System designed to streamline job requests, manage customer and admin profiles, assign products to delivery jobs, and monitor job status efficiently. The system includes separate dashboards for Admin and Customer users, each with a tailored feature set and user interface.

---

## 📌 Features

### 👨‍💼 Admin Panel
- View, add, update, and delete products
- Manage customers and job requests
- Assign available products to jobs
- Monitor stock and inventory
- Generate reports

### 👤 Customer Panel
- Register and login securely
- Submit new job requests
- Select required products for the job (with available quantity)
- Track job status (Pending, Approved, Completed)
- Manage profile details

---

## 📁 Project Structure
```
eShiftApp/
│
├── Forms/ # All UI forms for Admin, Customer, Login, etc.
│ ├── LoginForm.cs
│ ├── RegisterForm.cs
│ ├── AdminDashboard.cs
│ ├── CustomerDashboard.cs
│ ├── JobRequestForm.cs
│ └── ProductForm.cs
│
├── Database/
│ └── DBHelper.cs # Database connection handler
│
├── Reports/ # Various reports for report generation part
│ ├── JobsReport.rpt
│ └── CustomersReport.rpt
├
├── Properties/
│ └── Resources.resx # UI assets and resources
│
├── bin/ and obj/ # Compiled binaries (auto-generated)
│
├── App.config # DB connection string setup
├── Program.cs # Entry point
└── README.md # This file

```

---

## 🛠 Technologies Used

| Technology       | Purpose                              |
|------------------|---------------------------------------|
| C# (.NET)        | Main programming language             |
| Windows Forms    | GUI Development                       |
| Microsoft SQL Server | Backend database                  |
| Visual Studio    | Development Environment (IDE)         |
| ADO.NET          | Database operations                   |

---

## 🔧 Installation & Setup

1. **Clone this repository**
   ```bash
   git clone https://github.com/your-username/eShiftApp.git
   cd eShiftApp
   ```
---

## 🙋‍♂️ Author
#### Developed by Supun Akalanka
#### Final Year Application Development Project 01 – BEng (Hons) Software Engineering (TOP-UP)
#### London Metropolitan University / ESOFT Metro Campus

---
## 📃 License
#### This project is for educational purposes and not yet licensed for commercial distribution.
