The Note Taking App is a Windows Forms application developed using C#. This application serves as a tool for users to manage their notes effectively. It offers the following features:

Text Boxes:

newnote: This text box allows users to input and edit the content of their notes.
calendar: Displays the timestamp of the last update for the selected note.
Buttons:

save: Initiates the process of saving or updating notes.
delete: Enables users to delete the selected note.
open: Allows users to open and view the selected note.
Dropdowns:

DeleteBox: Users can select notes from this dropdown to delete.
oep: Provides a dropdown list of notes for users to select and open.
comboBox1: Offers a selection of different UI themes for users to customize the appearance of the application.
Labels:

Labels are used to provide guidance and information to users. They label various components such as text boxes, dropdowns, and buttons, improving the user experience by offering clear instructions.
Database Interaction:

The application interacts with a SQL Server database named "NoteDB" to store and retrieve notes.
SQL commands, executed through SqlConnection, SqlCommand, and SqlDataReader objects, facilitate database operations such as inserting, updating, deleting, and selecting notes.
UI Customization:

Users can choose from different UI themes using the comboBox1 dropdown. Changing the theme alters the colors of various components, allowing users to personalize their experience with the application.
In essence, the Note Taking App provides users with a user-friendly interface for managing notes efficiently. It integrates database functionality for storing and retrieving notes, alongside UI customization options, enhancing user productivity and satisfaction.
