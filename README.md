# Assignment For Carseer

## Setup and Installation Guide

### Option 1: Clone via Git

1. Open your terminal or command prompt.
2. Run the following command to clone the repository:
   ```bash
   git clone https://github.com/AnmarHussein/Assignment-For-Carseer.git
   ```

### Option 2: Clone via Visual Studio 2022

1. Open Visual Studio 2022.
2. Click on "Clone a repository" option.
3. Enter the repository location: https://github.com/AnmarHussein/Assignment-For-Carseer.git.
4. Click on "Clone".

## Running the Application

Once you have cloned the repository, follow these steps to run the application:

1. Open the project in Visual Studio 2022.
2. Ensure you have IIS Express installed.
3. Build the solution.
4. Run the application using IIS Express.

That's it! You should now have the application up and running.

# Fetching Car Models

## Overview

This guide outlines the process of fetching car models using a combination of input validation, CSV parsing, and API calls.

## Steps

### Step 1: Validate Input

Ensure that the provided make name and make year are valid to prevent errors during subsequent processes.

### Step 2: Get Make ID from CSV

Utilize the CsvHelper package to parse the `carmake.csv` file and retrieve the unique identifier (makeId) associated with the provided make name and year. You can accomplish this efficiently by employing either:

- Binary Search (recommended)
- Direct querying using LINQ

[ Note: ] For enhanced efficiency, consider applying the `_usingBinarySearch` flag during search operations.

### Step 3: Call Vehicle API using Refit

After validating the makeId and makeYear, invoke the Vehicle API using Refit. Refit simplifies API interactions, enabling you to define and invoke RESTful API interfaces in a type-safe manner.

## Why Use Refit?

Refit offers several advantages, including:

- Type-safe API interface definitions
- Simplified invocation of RESTful APIs
- Reduced boilerplate code
- Enhanced readability and maintainability of codebase

## Dependencies

Ensure that the following dependencies are installed:

- CsvHelper 32.0.3 package
- Refit 7.0.0 package
