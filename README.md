# Stock Tracking System (C# WinForms + MSSQL)

A desktop-based stock tracking application developed with C# Windows Forms (.NET Framework) and Microsoft SQL Server.  
This project allows managing products, categories, customers, sales, and sale details with full CRUD operations and search functionality.

---

## 🚀 Features

### ✅ Category Management
- Add / Update / Delete categories
- Live search by category name
- List categories in DataGridView

### ✅ Product Management
- Add / Update / Delete products
- Product listing with category name
- Category selection via ComboBox
- Live search by product name

### ✅ Customer Management
- Add / Update / Delete customers
- Customer fields: CustomerName, CustomerSurname, Phone
- Live search by customer name or surname

### ✅ Sales Management
- Add / Update / Delete sales
- Select customer via ComboBox
- SaleDate selection using DateTimePicker
- TotalAmount input and validation
- Search sales by customer name

### ✅ Sale Details Management
- Add / Update / Delete sale details
- Select Sale + Product via ComboBoxes
- Quantity and UnitPrice validation
- Automatic LineTotal calculation
- Search by product name

### ✅ Main Menu Navigation
- Sidebar menu for navigating forms
- Embedded form loading
- Exit confirmation dialog

---

## 🛠 Technologies Used

- C# (Windows Forms App - .NET Framework)
- Microsoft SQL Server (MSSQL)
- ADO.NET (SqlConnection, SqlCommand, SqlDataAdapter)
- DataGridView + ComboBox data binding
- SQL JOIN queries
- CRUD operations with validation

---

## 🗄 Database Structure

This project uses five main tables:

- Categories
- Products
- Customers
- Sales
- SaleDetails

Relationships:
- Products → Categories (FK)
- Sales → Customers (FK)
- SaleDetails → Sales (FK)
- SaleDetails → Products (FK)

---

## ⚙️ Setup Instructions

1) Clone the repository:

git clone https://github.com/mehmmetcann/stock-tracking-system.git

2) Open the solution in Visual Studio.

3) Create a database named:

StockDb

4) Create the required tables in SQL Server.

5) Update the connection string if needed:

string connectionString = @"Server=localhost\SQLEXPRESS;Database=StockDb;Trusted_Connection=True;";

6) Run the project.

---

## 📷 Screenshots

### 🧭 Main Menu
![Main Menu](screenshots/mainmenu.png)

### 🗂 Categories Screen
![Categories](screenshots/categories.png)

### 📦 Products Screen
![Products](screenshots/products.png)

### 👤 Customers Screen
![Customers](screenshots/customers.png)

### 🧾 Sales Screen
![Sales](screenshots/sales.png)

### 📑 Sale Details Screen
![Sale Details](screenshots/saledetails.png)

---

## 🎯 Project Purpose

This project was built to practice:

- MSSQL relational database design
- Foreign key relationships
- ADO.NET database operations
- WinForms UI design
- Navigation between forms
- Real-world CRUD operations with validations

---

## 👤 Developer

Mehmetcan  
Computer Engineering Student  
Portfolio / Personal Project
