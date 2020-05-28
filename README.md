# TextToVoice
C# code used to create the intro and outro text for the Azure Security Podcast, using Azure Cognitive Services.

The code is bare-bones, but it works :)

To use this you need to:

- Hop into your Azure subscription, you can get a free one if needed, just head to azure.com
- Add a new Cognitive Services Speech resource (Search for Cognitive in the search bar, Add a Cognitive resource, and then type Speech in the in the Marketplace)
- Now enter the approp details, you can use the free tier (F0) but you can only have one of these per subscription.
- Once this is done, click Keys and Endpoint and take note of the first key and the location
- Plug the key into the app.config file as well as the location
- Edit the text you want to conver from text.
- Compile and run the code.
- Open and listen to the resulting WAV file.

### Supporting screenshots

#### Select the correct Cognitive Service:
![](Annotation%202020-05-28%20163246.png)

#### Getting a key and the location:
![](Annotation%202020-05-28%20151438.png)

