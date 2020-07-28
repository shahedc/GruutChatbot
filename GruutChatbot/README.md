# GruutChatbot

Bot Framework v4 echo bot sample.

This bot has been created using [Bot Framework](https://dev.botframework.com), it shows how to create a simple bot that accepts input from the user and echoes it back.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) version 3.1

  ```bash
  # determine dotnet version
  dotnet --version
  ```

## Azure Cognitive Services setup

This project leverages Text Analytics from Azure Cognitive Services, which analyzes the user's sentiment to know what tone Gruut should reply with.

You will need to do the following:

1. Create a text analytics resource in Azure
2. From the new resource, go to `Keys and Endpoint` and grab a key and the endpoint URI
3. Create a new Azure Key Vault or use an existing one
4. Create two secrets, `AzureKeyCredential` and `CognitiveServicesEndpoint` with the values from the last step
5. Go to **Azure Active Directory** > **App registrations** > **New registration** (accept default)
6. Take note of the application (client ID)
7. Still in Azure AD, go to **Certificates & secrets** > **New client secret**
8. Take note of generated secret
9. From your Key Vault, go to **Access policies** > **Add access policy**.
10. Set secret permissions to **Get** and **List**, set principal to app registration you created

Finally, add an `appsettings.json` in the `GruutChatbot`project with the following structure:

```
{
	"KeyVault": {
		"Name": "<name-before-vault.azure.net>",
		"ClientId": "<referenced earlier>",
		"ClientSecret": "<referenced earlier>"
	}
}
```

## To try this sample

- In a terminal, navigate to `GruutChatbot`

    ```bash
    # change into project folder
    cd # GruutChatbot
    ```

- Run the bot from a terminal or from Visual Studio, choose option A or B.

  A) From a terminal

  ```bash
  # run the bot
  dotnet run
  ```

  B) Or from Visual Studio

  - Launch Visual Studio
  - File -> Open -> Project/Solution
  - Navigate to `GruutChatbot` folder
  - Select `GruutChatbot.csproj` file
  - Press `F5` to run the project

## Testing the bot using Bot Framework Emulator

[Bot Framework Emulator](https://github.com/microsoft/botframework-emulator) is a desktop application that allows bot developers to test and debug their bots on localhost or running remotely through a tunnel.

- Install the Bot Framework Emulator version 4.5.0 or greater from [here](https://github.com/Microsoft/BotFramework-Emulator/releases)

### Connect to the bot using Bot Framework Emulator

- Launch Bot Framework Emulator
- File -> Open Bot
- Enter a Bot URL of `http://localhost:3978/api/messages`

## Deploy the bot to Azure

To learn more about deploying a bot to Azure, see [Deploy your bot to Azure](https://aka.ms/azuredeployment) for a complete list of deployment instructions.

## Further reading

- [Bot Framework Documentation](https://docs.botframework.com)
- [Bot Basics](https://docs.microsoft.com/azure/bot-service/bot-builder-basics?view=azure-bot-service-4.0)
- [Activity processing](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-concept-activity-processing?view=azure-bot-service-4.0)
- [Azure Bot Service Introduction](https://docs.microsoft.com/azure/bot-service/bot-service-overview-introduction?view=azure-bot-service-4.0)
- [Azure Bot Service Documentation](https://docs.microsoft.com/azure/bot-service/?view=azure-bot-service-4.0)
- [.NET Core CLI tools](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)
- [Azure CLI](https://docs.microsoft.com/cli/azure/?view=azure-cli-latest)
- [Azure Portal](https://portal.azure.com)
- [Language Understanding using LUIS](https://docs.microsoft.com/en-us/azure/cognitive-services/luis/)
- [Channels and Bot Connector Service](https://docs.microsoft.com/en-us/azure/bot-service/bot-concepts?view=azure-bot-service-4.0)
