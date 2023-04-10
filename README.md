# NotesAPI

## Introduction

A RESTful API created to work as a virtual Agenda. With this API you can create, check, update and delete your event notes easily.

Functionalities:

- Create Note
  You can create a Note passing a predertermined Category (Work, Family Events, Study and General), Title (to describe the event), TargetDate (a date to set when the     event will happend *The DateTime accept only month-day-year format*) and Content (to put additional information).
  
- Get Notes By Target Date
  Allows to see all the notes created for that specific day. It shows all Notes information: Category, Title, TargetDate, LastUpdateDate, Content and the Note Id.
  
- Get Notes By Category
  Allows to see all the notes createdfor that specific category. It shows all Notes information: Category, Title, TargetDate, LastUpdateDate, Content and the Note Id.
  
- Update a Note Target Date
  Update a Note Target Date by it's Id. 
  
- Delete Note
  Delete a Note by it's Id. 
  

## Technologies

- ASP.NET
- C#
- SQL

## Setup

This project uses SQL Server as data base to store the Notes information, so to have the API working properlly you'll need to set up your database accordingly.
First you'll need to create your own database at SQL Server and configure your connection string at CustomerAPI\appsettings.json. After doing this, it's time to generate all the SQL schemas from the Entity Framework Models present in the project. This can be done using the file located at CustomerAPI\Repositories\SQLMigration.NotesAPI.sql. All you need to do is to copy it's content and run it at you data base (the same you added at the connection string). Following those steps the setup is complete.


## To Do

- For now the SQL schema generation has to be done by using the .sql file mentinoed in the Setup section. But further the EF Migration will be automated.
- Customize the DateTime fields insertion to have more of a 'user friendly' display.
- The idea for this virtual agenda expansion is to have a subscription logic. The client will provide his email and set up an specific hour during their subscrition, then start creating/updating/deleting Notes. After this subscription, every day, at the hour set, the client will receive an email with all the notes that he created for that day - this will imply in the removal of GetByTargetDate call.
