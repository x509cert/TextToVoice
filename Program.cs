using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Threading.Tasks;
using System.Configuration;

namespace helloworld
{
    static class Synth
    {
        public static async Task SynthesisToAudioFileAsync()
        {
            var sub = ConfigurationManager.AppSettings["sub"];
            var region = ConfigurationManager.AppSettings["region"] ?? "southcentralus";
            var outFilename = ConfigurationManager.AppSettings["filename"] ?? "voice.wav";
            var text = ConfigurationManager.AppSettings["text"];
            var voice = ConfigurationManager.AppSettings["voice"] ?? "en-US-JessaNeural";

            var config = SpeechConfig.FromSubscription(sub, region);
            using (var fileOutput = AudioConfig.FromWavFileOutput(outFilename))
            {
                using (var synthesizer = new SpeechSynthesizer(config, fileOutput))
                {
                    var xmlSpeech = 
                        @"<speak version='1.0' xmlns='https://www.w3.org/2001/10/synthesis' xml:lang='en-US'>" +
                        @"<voice name='" + voice + "'>"+
                        text + 
                        @"</voice></speak>";

                    var result = await synthesizer.SpeakSsmlAsync(xmlSpeech);

                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        Console.WriteLine($"Speech synthesized to [{outFilename}] for text [{text}]");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED: {cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: {cancellation.ErrorCode}\n{cancellation.ErrorDetails}");
                        }
                    }
                }
            }
        }

        private static void Main()
        {
            SynthesisToAudioFileAsync().Wait();
        }
    }
}
