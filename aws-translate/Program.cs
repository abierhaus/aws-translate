using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.Translate;
using Amazon.Translate.Model;

namespace aws_translate
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //Set Logging level

            AWSConfigs.LoggingConfig.LogTo = LoggingOptions.Console;
            AWSConfigs.LoggingConfig.LogMetrics = true;
            AWSConfigs.LoggingConfig.LogResponses = ResponseLoggingOption.OnError;

            //Call translate function
            await Translate("The quick brown fox jumps over the lazy dog");
        }

        public static async Task Translate(string text, string sourceLangaugeCode = "en",
            string targetLangaugeCode = "de")
        {
            //Generate the client, Note: The config is used from your initital CLI configuration
            var translate = new AmazonTranslateClient();
            //Build up request
            var request = new TranslateTextRequest
                {Text = text, SourceLanguageCode = sourceLangaugeCode, TargetLanguageCode = targetLangaugeCode};

            //Call translate service
            var translation = await translate.TranslateTextAsync(request);


            Console.WriteLine(translation.TranslatedText);
        }
    }
}