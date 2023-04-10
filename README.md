# NotesAPI

## Introduction

A RESTful API created to work as a virtual Agenda. With this API you can create, check, update and delete your event notes easily.

###Functionalities

- Create Note
  You can create a Note passing a predertermined Category (Work, Family Events, Study and General), Title (to describe the event), TargetDate (a date to set when the     event will happend) and Content (to put additional information).
  
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

This project works using SQL Server as data base to store the Notes information. 
