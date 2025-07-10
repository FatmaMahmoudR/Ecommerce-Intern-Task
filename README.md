# E-commerce Console App

A simple console-based e-commerce simulation demonstrating a clean MVC structure and SOLID principles in C#.  
You can list all products, add items to your cart and perform checkout, with model-level validation and dependency injection.


## Features

- **Product Listing** (with expirable/shippable behaviours)
- **Add to Cart** (stock, expiration and quantity validations)
- **Checkout** (subtotal, shipping calculation, balance check)
- **Model Validation** in constructors and via interfaces (IExpirable, IShippable)
- **Clean MVC Layering**:
  - **Models**: domain entities 
  - **Services**: business logic, in-memory data  
  - **Views**: console I/O  
  - **Controllers**: call services and pass results to Views
- **Dependency Injection** 


## Concepts used 
  - MVC Pattern: separates models, views, and controllers for clear responsibilities.
  - Dependency Injection: wires interfaces to implementations in the Program.cs.
  - Interface-Driven Design: controllers depend on service and view interfaces rather than concretes.
  - SOLID Principles: enforces single responsibility and dependency inversion.
  - LINQ: used for product searches and total/weight calculations.
  - Behavioural Interfaces: IExpirable & IShippable enable expiry and weight checks.

<br/><br/>

| <img src="https://github.com/user-attachments/assets/3fc9ebe7-6530-4892-8cac-6a8234f55eeb" width="800" alt="Checkout Success" /> | <img src="https://github.com/user-attachments/assets/50aa3ede-d489-4dee-a022-9222d3f79e3c" width="800" alt="Checkout Failure" /> |
|:---:|:---:|
| **Checkout Success** | **Checkout Failure** |
