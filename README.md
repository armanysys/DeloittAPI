# Deloitt

## API Methods

- **GetProducts()**: This method returns all products that are currently stored in the warehouse.
- **SetProductCapacity(productId, capacity)**: This method sets the maximum storage capacity for the specified product.
- **ReceiveProduct(productId, qty)**: This method increments the current quantity of a product stored in the warehouse.
- **DispatchProduct(productId, qty)**: This method decrements the current quantity of a product stored in the warehouse.


## Product API Methods

## Overview
The `ProductsController` manages product-related operations such as retrieving all products, setting product capacity, receiving products, and dispatching products.

## API Endpoints

### GET: api/GetProducts
- Retrieves a list of all products.
- **Response**: `200 OK` with a list of products.

### POST: api/products/SetProductCapacity/{productId}/{capacity}
- Sets the capacity for a specific product.
- **Parameters**:
  - `productId`: The ID of the product.
  - `capacity`: The new capacity to set.
- **Response**: 
  - `200 OK` with a success message if the operation is successful.
  - Error response based on the service response status otherwise.

### POST: api/products/ReceiveProduct/{productId}/{quantity}
- Receives a specified quantity of a product.
- **Parameters**:
  - `productId`: The ID of the product.
  - `quantity`: The quantity to receive.
- **Response**: 
  - `200 OK` with a success message if the operation is successful.
  - Error response based on the service response status otherwise.

### POST: api/products/DispatchProduct/{productId}/{quantity}
- Dispatches a specified quantity of a product.
- **Parameters**:
  - `productId`: The ID of the product.
  - `quantity`: The quantity to dispatch.
- **Response**: 
  - `200 OK` with a success message if the operation is successful.
  - Error response based on the service response status otherwise.

## Error Handling
The controller handles errors by returning appropriate HTTP status codes and messages based on the service response status:
- `404 Not Found` if the item is not found.
- `400 Bad Request` for validation errors or bad requests.
- `500 Internal Server Error` for any other server errors.
