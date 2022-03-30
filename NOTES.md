## ============<DATABASE LECTURE>==============

# -----------<IN POSTMAN>--------------
- GET ALL:
    - http://localhost:5000/api/bakers
    - Nothing in Params
- GET one
    - http://localhost:5000/api/bakers/:id
    - Nothing in Params
- POST
    - http://localhost:5000/api/bakers
    - In Body, select "raw" and in dropdown "JSON", write in the object parameters and values -> {"name" : "Kris"}
- DELETE
    - http://localhost:5000/api/bakers/:id
    - Nothing in body or params
- PUT
    - http://localhost:5000/api/bakers
    - 
- PATCH
    - http://localhost:5000/api/bakers
    - 

# ----------<In Terminal>--------------
- 1.) git clone
- 2.) dotnet restore
    - * (Similar to npm install)
- 3.) dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
    - * (For starting from scratch)
- 4.) dotnet add package Microsoft.EntityFrameworkCore.Design
    - * (For starting from scratch)

- 5.) dotnet tool install --global dotnet-ef
    - * (Installs the Entity Framework (EF) command line tool)
    - * (Allows us to run special commands to our database when we need to *)

- 6.) dotnet restore

- 7.) dotnet ef migrations add CreateBakerTable
    - * (Creates a new migration moving model changes to the database)

- 8.) dotnet ef database update
    - * (Will send the code from a file in the Migrations folder to actually create the database table)

- 9.) dotnet watch run
    - * (Gets the server up and running)

- 10.) dotnet ef migrations add CreateBreadTable
    - * (Generates the migration files for Bread)

- 11.) dotnet ef database update
    - * (Run the migration)

# ---------<EF>------------
- Stands for: Entity Framework
- Replaces our pg
- ORM
    - Object
    - Relation
    - Mapper

# ---------<THE PROCESS>--------------
- Our Model Classes will go through the EF to talk to the database

# ---------<DATABASE CONNECTION>--------------
- EF needs to know how to connect to our database, this is already set up for us in (appsettings.json) and (Startup.cs)
- This is similar to how we setup our pool.js file with node-postgres

# ---------<ERD>--------------
- This app will have two tables, one for bakers, one for breads
- This is a one-to-many relationship (a baker has many breads)
- Instead of setting up this database with SQL commands in postico, we'll use our EF to create out database tables for us

# ---------<MODEL SETUP: Baker>--------------
- Think about the relationship between Bread and Baker, Bakers make and own bread, so we'll start with a baker in our Baker.cs class

# ---------<ACTIVATE BakerModel IN DATABASE>--------------
- ApplicationContext is the way we talk to our database
- In ApplicationContext.cs we need to activate our class that corresponds to a table

# ---------<DATABASE MIGRATIONS>--------------
- A migration is a way of moving your model changes to the database
- We can make multiple database migrations, every time we change one of our models
- Think of migration like git commit, but tracking changes to the database instead of to code
- After making the migration to track our Baker model as a database table, this will create a new file in the Migrations folder. Which is C# code of a series of commands to create a database table matching the Baker model

# ---------<Baker CONTROLLER>--------------
- After creating a Baker model and a Bakers database table, we will create a BakersController so we can make API requests to a /api/bakers endpoint
- _context.Bakers is essentially our "pool"
- _context is an instance of our ApplicationContext class. In this class we see that _context.Bakers is a property with the type DbSet<Baker>
- These DbSet properties are "mapped" to the database tables, which means we can just return _context.Bakers and .NET will make an SQL query for us and find all the records from the Bakers table

# ---------<Bread MODEL>--------------
- What we need for a bread object:
    - Primary Key (id)
    - Name
    - Description
    - Bread type -- which?
    - Count -- how many?
    - bakerId (who made it?)

# ---------<Bread MODEL CLASS>--------------
- * CODE *

# ---------<ENUM TYPES>--------------
- For the bread type, we could use a string, but instead we'll use a special Enum type:
- Think of an Enum as a string that may only have a few possible values
- That way if you try to POST another bread type to the API it will automatically return a 400 error

# ---------<ACTIVATE Bread IN DATABASE>--------------
- Tell .NET that the Bread model should be "mapped" to a database table in ApplicationContext.cs

# ---------<Bread TABLE MIGRATION>--------------


# ---------<Bread CONTROLLER>--------------

