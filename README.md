**DSV Swapi API**
=====================  

This API was created as part of the task related to the DSV selection process. The requirements were to create an API
based on [SWAPI](https://swapi.dev/); however, since that API was unavailable, the following was used as a
reference: [SWAPI Py4E](https://swapi.py4e.com/documentation).

The following entities were chosen to complete the task: **Planets** and **Residents**.

- **Planets**: Represent the planets that may exist in the Star Wars universe (SW).
- **Residents**: Represent the named residents who live on each planet.

**Important**: Only a few fields were selected for the entities to simplify the implementation.
 

**Frameworks and Tools:**
=====================
This API was developed using the following technologies and tools:

- **.NET Core WEB API**: To create the RESTful API.
- **EF Core**: For database management and ORM (Object-Relational Mapping).
- **xUnit**: To implement unit tests for ensuring code quality and functionality.
- **Autofixture**: For automatic creation of test mocks and test data generation.
- **Docker**: To create a local SQL Server database for testing and development environments.


**API Documentation**
------------  

# API Documentation for DSVSwapi

## Overview

This document provides an overview of the API endpoints available in the `DSVSwapi.Api` service. The API is designed to
manage information about planets and their residents. It follows the OpenAPI Specification 3.0.1.

---

## Base URL

All endpoints are prefixed with `/v1/`.

---

## Endpoints

### **Planets**

#### GET `/v1/Planets`

- **Description**: Retrieves a list of all planets.
- **Responses**:
    - `200`: Success

#### POST `/v1/Planets`

- **Description**: Creates a new planet.
- **Request Body**:
    - **Content-Type**: `application/json`, `text/json`, or `application/*+json`
    - **Schema**: [PlanetDTO](#schemas)
- **Responses**:
    - `200`: Success

#### GET `/v1/Planets/{id}`

- **Description**: Retrieves details of a specific planet by its ID.
- **Path Parameters**:
    - `id` (integer, required): The ID of the planet.
- **Responses**:
    - `200`: Success

#### PUT `/v1/Planets/{id}`

- **Description**: Updates an existing planet by its ID.
- **Path Parameters**:
    - `id` (integer, required): The ID of the planet.
- **Request Body**:
    - **Content-Type**: `application/json`, `text/json`, or `application/*+json`
    - **Schema**: [PlanetDTO](#schemas)
- **Responses**:
    - `200`: Success

#### DELETE `/v1/Planets/{id}`

- **Description**: Deletes a planet by its ID.
- **Path Parameters**:
    - `id` (integer, required): The ID of the planet.
- **Responses**:
    - `200`: Success

---

### **Residents**

#### GET `/v1/Residents`

- **Description**: Retrieves a list of all residents.
- **Responses**:
    - `200`: Success

#### POST `/v1/Residents`

- **Description**: Creates a new resident.
- **Request Body**:
    - **Content-Type**: `application/json`, `text/json`, or `application/*+json`
    - **Schema**: [ResidentDTO](#schemas)
- **Responses**:
    - `200`: Success

#### GET `/v1/Residents/{id}`

- **Description**: Retrieves details of a specific resident by their ID.
- **Path Parameters**:
    - `id` (integer, required): The ID of the resident.
- **Responses**:
    - `200`: Success

#### PUT `/v1/Residents/{id}`

- **Description**: Updates an existing resident by their ID.
- **Path Parameters**:
    - `id` (integer, required): The ID of the resident.
- **Request Body**:
    - **Content-Type**: `application/json`, `text/json`, or `application/*+json`
    - **Schema**: [ResidentDTO](#schemas)
- **Responses**:
    - `200`: Success

#### DELETE `/v1/Residents/{id}`

- **Description**: Deletes a resident by their ID.
- **Path Parameters**:
    - `id` (integer, required): The ID of the resident.
- **Responses**:
    - `200`: Success

---

## Schemas

### **PlanetDTO**

- **Description**: Represents a planet.
- **Properties**:
    - `id` (integer): The unique ID of the planet.
    - `name` (string, nullable): The name of the planet.
    - `climate` (string, nullable): The climate of the planet.
    - `terrain` (string, nullable): The terrain of the planet.

### **ResidentDTO**

- **Description**: Represents a resident of a planet.
- **Properties**:
    - `id` (integer): The unique ID of the resident.
    - `name` (string, nullable): The name of the resident.
    - `gender` (string, nullable): The gender of the resident.
    - `planetId` (integer): The ID of the planet the resident belongs to.
    - `planet` ([PlanetDTO](#schemas)): Detailed information about the planet.

---


**Prerequisites**
---------------  

To run the project, you need to have Docker installed on your machine. The development SQLServer database is configured
in the `docker-compose` file.

**Technical Stack**: .Net Core
-----------------  

**Getting Started**
-------------------  

To get started with the project, simply run `docker-compose up` to start the development environment.
Then, you can use a tool like `curl` or a REST client to interact with the API endpoints.

Was not added any Authorization Handler.

### Build/Run Scripts

    docker-compose -f docker/docker-compose.yaml up -d

### Create Database Migrations 

    dotnet ef migrations add NomeDaMigration

### Apply Database Migrations 

    dotnet ef database update

