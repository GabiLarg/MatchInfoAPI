using System.Collections.Generic;
using Google.Cloud.Language.V1;

namespace MatchInfo.Repository
{
    public interface IAnalyzer
    {
        IEnumerable<ClassificationCategory> GetCategories(string request);

        Sentiment GetSentiments(string request);
    }
}
