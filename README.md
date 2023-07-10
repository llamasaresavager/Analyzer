# CodeQL Analyzer

The CodeQL Analyzer is a set of tools used to analyze the structure of C# repositories and extract the file structure into a JSON format. The toolset consists of two main parts: 

1. A C# application that leverages the CodeQL command line interface to analyze the code base and generate the JSON output.
2. A Python-based graphical user interface (GUI) to present the output data in a user-friendly way.

## 1. C# Code Analyzer

This C# application interfaces with the CodeQL CLI to analyze the file structure of a C# repository. It creates a CodeQL database for the provided repository and queries the file structure of the code. The structure is then output in JSON format.

### Usage

- Clone this repository to your local machine.
- Open the solution in Visual Studio.
- In the `Program.cs` file, replace the `repoPath` variable with the path to the C# repo you wish to analyze.
- Replace the `outputFolderPath` variable with the directory where you'd like the output JSON file to be saved.
- Run the program.

The application will create a CodeQL database for the specified repo, find the files within, and output the structure in JSON format to the specified output directory.

## 2. Python User Interface

This Python application provides a GUI for viewing the JSON file output by the C# application. It presents the file structure in a tree-like view for easy navigation and understanding.

### Usage

- Ensure you have Python installed on your machine.
- Clone this repository to your local machine.
- Navigate to the directory containing the Python script.
- Run the script with `python ui.py`.

When the script runs, it opens a GUI window. You can then navigate to your output JSON file using the `Open` button in the application.

## Prerequisites

- CodeQL CLI installed on your machine. You can get it from [GitHub's CodeQL repository](https://github.com/github/codeql-cli-binaries).
- .NET SDK for running the C# application.
- Python for running the Python script.

## Future Work

- Integrate the two components into a single application.
- Automate the analysis of multiple repositories.
- Add support for other programming languages.

## Contributing

Contributions are welcome. Please submit a pull request or create an issue to discuss the changes you wish to make.

## License

This project is licensed under the MIT License.

## Author

Your Name

---

This README should provide a good starting point for your project. You can, of course, customize it to fit your specific needs.
