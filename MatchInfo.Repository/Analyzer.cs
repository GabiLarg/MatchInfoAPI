using System.Collections.Generic;
using Google.Cloud.Language.V1;

namespace MatchInfo.Repository
{
    public class Analyzer: IAnalyzer
    {
        public Analyzer(){ }

        public IEnumerable<ClassificationCategory> GetCategories(string request)
        {
            var client = LanguageServiceClient.Create();
            var response = client.ClassifyText(new Document()
            {
                Content = request,
                Type = Document.Types.Type.PlainText
            });
            return response.Categories;

        }

        public Sentiment GetSentiments(string request)
        {
            var client = LanguageServiceClient.Create();
            var response = client.AnalyzeSentiment(new Document()
            {
                Content = request,
                Type = Document.Types.Type.PlainText
            });

            return response.DocumentSentiment;
        }

    }
}
