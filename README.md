# CustomConnectorCodeProject
Microsoft Power Platform represents the power of 'low-code' solution development for the business or citizen developer.  The Custom Connector feature is one of the areas in the platform where pro-developers may initially provide their skills and experience to enable applications using line of business (LOB) data.  The process of creating a Custom Connector is listed in the documentation [here](https://docs.microsoft.com/en-us/connectors/custom-connectors/define-blank).

The custom connector basically calls an API endpoint end, providing any required security and makes that data available to a PowerApp or Power Automate. A recent enhancement to the original custom connector now provides the ability to manipulate the reponse from the underlying API via a custom C# code class.  This class needs to inherit from ScriptBase and implement the appropriate methods.

The UI for this functionality provvides for uploading a single .cs file.  The interactive textbox does provide for some limited editing.  This means you should have a working file before uploading as the debugging process/feedback is kind of limited.  This [file](https://docs.microsoft.com/en-us/connectors/custom-connectors/write-code) provides information on writing the code section of the custom connector.

Console project for creating 'Code' section of a custom connector.  Includes appropriately named classes and interfaces so all you need to do is upload the Script.cs file.

## Instructions
Create a local instance of this repo through either:
- Fork the repo into your account.  
- Clone locally or open in CodeSpaces.

The CodeSegment folder of this repo contains a .NET Core console application.  

In the Program.cs, replace the token [REPLACE WITH CUSTOM CONNECTOR URL] with the api url endpoint.  This url should fully resolve and return the data expected from the connector method.

Add any additional headers to complete the Http Request.  

A line of code is include for the API-M Subscription header.  Uncomment this and provide your subscription key if using API-M.

Update the Script.cs file to modify the response object before sending it back to the app/automate that requested it.

Once the code is tested and ready for deployment, comment out or delete the 'CreateJsonContent' method in the Script.cs.  You can't have the override method in your class file, eventhough you need it to fully implement the interface.

The Script.cs file can be uploaded to the Code section of the Custom Connector.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft 
trademarks or logos is subject to and must follow 
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.