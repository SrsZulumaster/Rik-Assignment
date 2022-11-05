# Rik-Assignment

This Assignment was made for Riigi Infosüsteemide Keskus.

The application uses MSSQL Local Database.
This application was made using .Net(C#), Razor pages.
The front-end styilng was done with Bootstrap.

The application allows the User to create events, edit future events and add participants to future events.
It keeps track of past events and those who participated in them.

Possible issues:
Since i was unable to test the application on different devices, then there may be issues with the Database.
It might need starting up.

Make sure you have a MSSQL Local server running:
Run "Update-Database" command

If this didnt work:
Check that in appsettings.json the Connection string for "Rik_AssignmentContext" to match your settings.
then run  "Update-Database" command again
