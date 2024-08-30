# SAOnlineMart

## Built according to the specification of Eduvos for the ITEHA Individual Assignment. 

An ASP.Net Core Web app with basic customer and administrator functionality, including:
- Browsable product catalogue
- Functional cart system
- Order placement functionality
- User accounts
- Seeded products and admin account
- Administrative pages for CRUD operations on products

## How to set up
1. Clone the 'main' branch in Visual Studio 2022

2. Initialize the database

    Use the following script in order, entered into the NuGet Package Management Console

    add-migration init

    update-database

3. Use Build>Build Solution

   If any errors appear, it is most likely for NuGet Packages which are not installed. The error text should give information on which package you need to install through NuGet Package Manager.

4. Finally, ensure the project is selected to use 'http' before running Debug>Start with/without Debugging.

    The seeded default administrative account can be found in 'SAOnlineMartContext.cs'

## Contribution guidelines
### Report bugs using Github's [issues][(https://github.com/RenierDB/SAOnlineMart/issues)]
Report a bug by opening a new Issue.

### Use a consistent and cleaned coding style
Use 4 spaces for indentation
Please use Visual Studio's built in Code Cleanup tool before submitting pull requests.
