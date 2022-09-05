# Custom Connector Code Project
This is dotnet Core v6 console project for locally creating the 'Code' section of a custom connector.  This project provides everything you need to develop the script on your machine using all of the appropriately named classes and interfaces that exist in the custom connector.  Write your code in this project and then upload the Script.cs file into the Code section of you custom connector once your local testing is complete.

## Getting Started
The 'main' branch of this repository contains the basic structure required for you to add your code.  The following variables are available in the Program.cs file:
* CustomConnectorUrl (Required) - The URL of the API used by the custom connector. 
* OperationID (Required) - The operation ID as defined in the custom connector.  This code only handles 1 operation ID, but there could be multiple operations and this allows the code flow to process the appropriate response.
* OcpApimSubscriptionKey (Optional) - The API key used by the custom connector to authenticate against API-M.  This is only required if the API is behind a Subscription Key secured API-M instance.

With these values added to the Program.cs file, you can run the project and it will return the Http response from the API.  At this point, you can make the changes to the response using the Script.cs file.


There is also a 'sample' branch which shows a working example based on the Conference API scenario.  This branch is a good starting point if you are new to custom connectors and want to see a working example of the code section.

## Custom Connector Documentation
[Overview of Power Platform Custom Connectors](https://docs.microsoft.com/en-us/connectors/custom-connectors/)

[Creating a Custom Connector from Scratch](https://docs.microsoft.com/en-us/connectors/custom-connectors/define-blank)

[Writing Code in a Custom Connector](https://docs.microsoft.com/en-us/connectors/custom-connectors/write-code)

## Issues
Use the [Issue Tracker](https://github.com/richross/CustomConnectorCodeProject/issues) for this repo to report bugs or request features.

Thanks!
