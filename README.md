# VendingMachineApp
One of the projects I worked on was a **full-stack vending machine web application** that simulates the functionality of a real vending machine through a web interface. The goal of the project was to allow users to browse available products, select items, and complete purchases while the system manages inventory and transaction records behind the scenes.

For the **frontend**, I used **Angular with TypeScript** to build the user interface. I created components to display the available products, including information such as the product name, price, and quantity available. The interface allowed users to select items they wanted to purchase and view product details in an organized layout. I also implemented Angular services to handle communication with the backend API, which helped separate the UI logic from the data and business logic. Using Angular’s component-based structure made the application easier to maintain and expand.

On the **backend**, I built a **RESTful API using ASP.NET Core with C#**. The backend handled the main business logic of the application. When a user selected a product to purchase, the API would check whether the product was available in stock. If the item was available, the system would process the purchase and update the inventory accordingly. The backend was structured using controllers, models, and service layers to keep the code modular and organized.

For **data storage**, I used **SQL Server**. I designed tables to store product information and transaction records. The products table included fields such as product ID, product name, price, and quantity available. The transactions table recorded details about each purchase, including the product purchased and the date of the transaction.

This project helped me gain experience working across the **full development stack**, integrating frontend interfaces, backend APIs, and database systems to build a complete and functional application.

# Vending Machine Application - Frontend

This is the Angular frontend for the Vending Machine application.

## Prerequisites

- Node.js (v14 or higher)
- Angular CLI (v12 or higher)

## Installation

1. Clone the repository and navigate to the frontend directory:
   ```
   cd vending-machine-app/frontend
   ```
2. Install dependencies:
   ```
   npm install
   ```

## Running the Application

Start the Angular development server:
```
ng serve
```
The app will be available at [http://localhost:4200](http://localhost:4200).

## Features

- **Landing Page**: Enter amount, select item, purchase, and see transaction messages/change.
- **Inventory Management**: Add, update, or remove items. View inventory change log.
- **Report Page**: Generate and download purchase reports (PDF/Excel).

## API Integration

- The frontend communicates with the backend API at `http://localhost:5000`.
- Ensure the backend is running before using the frontend.

## Testing

To run unit tests:
```
ng test
```

## License

MIT License. See the LICENSE file for details.
