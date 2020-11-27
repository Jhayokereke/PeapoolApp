# week-1-task-Jhayokereke
## Week 1 Task

Problem Description:

Your task is to create a console application that models a “User authentication service system” using OOP concepts.

The application should be able to keep track of registered users using a list. So that the registration history of the users can be requested at any point as the application is still running.

Required Features

· A User should have a unique ID, Name, Email, Password, Role, DateCreated, List<PhoneNumber>

· User password must be encrypted

· Role is either Admin or Regular

Required Functionalities

· A user should be able to register (Create an account).

· A user should be able to login.

· A user should only be able to update records such as (Name, Email, Password, List<PhoneNumber>).

· A user with the role “Admin” should be able to print the history of registered users.

A user with the role “Admin” should be able to delete a single user by Id or All Users except himself and users with role Admin

Output schema:

ID: “string”

Name: “string”,

Email: “string”,

Password: “string”,

Role: “string”,

Date Created: “datetime”,

Phone numbers: [“string”,“string”]

Example of output:

[

{

ID: eiodf-d0-d909.dfmed45454434,

Name: John Doe, Email: johndoe@example.com

Password: dfrr9rg90rg90-ee-09e909-rff,

Role: Regular,

Date Created: 11/23/2020

Phone numbers: 09876543211, 09876543000

},

{

ID: eiodf-d0-d909.dfmed4j7754434,

Name: Jane Doe, Email: janedoe@example.com

Password: dfrr9rg65rg90-ee-09e909-rff,

Role: Admin,

Date Created: 11/23/2020

Phone numbers: 09876544211, 09876643000

}

]

Submission Instruction

All code submission should be done via GitHub classroom using the link below:

https://classroom.github.com/a/QXNc3CBq

Test Coverage: None