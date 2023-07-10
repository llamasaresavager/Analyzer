# Code Base Analyzer

The Code Base Analyzer is a tool designed to extract the file structure of a C# repository, store it as a JSON file, and provide an interface to interact with the generated file structure. This repository consists of two main components:

1. A **C# Application** that generates the file structure of a given C# repository in the form of a JSON file.
2. A **Python GUI Application** that loads the JSON file and provides a GUI to interactively select or exclude directories and files. 

## C# Application

The C# application uses the `System.IO` namespace to traverse the directory structure and `System.Text.Json` for serialization. The application also takes into account `.gitignore` rules as well as excludes `bin` and `obj` directories.

**Running the Application**
To run the C# application, open the solution in Visual Studio and press `F5`, or run the application from the command line using `dotnet run`.

## Python GUI Application

The Python GUI application uses the Tkinter library to provide a simple interface that displays the JSON file structure in a tree-like view with checkboxes next to each item. Selected items can be excluded and the resulting file tree can be saved as a new JSON file.

**Running the Application**
To run the Python GUI application, navigate to the directory containing the script in the terminal and run `python app.py`.

## Requirements
- .NET 5.0 or later for the C# application.
- Python 3.6 or later with Tkinter installed for the Python GUI application.

## Usage
1. Run the C# application, specifying the repository path and the output folder path as command line arguments.
2. Run the Python GUI application. You will be asked to select the JSON file generated by the C# application.
3. In the GUI, select or deselect directories and files as desired. 
4. Click the "Save" button to save the modified file structure as a new JSON file.
