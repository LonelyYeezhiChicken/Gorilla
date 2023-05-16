using System.Text;

namespace API.SDK
{
    public class ChatGPT
    {
        public static Result CallChatGPT(string msg)
        {
            HttpClient client = new();
            string uri = "https://api.openai.com/v1/completions";

            string token = Environment.GetEnvironmentVariable("API_KEY")
                            ?? throw new NullReferenceException("未設定連線字串環境變數");

            // Request headers.
            client.DefaultRequestHeaders.Add(
                "Authorization", $"Bearer {token}");

            var JsonString = @"
            {
  ""model"": ""text-davinci-003"",
  ""prompt"": ""question"",
  ""max_tokens"": 4000,
  ""temperature"": 0
}
            ".Replace("question", msg);
            var content = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var response = client.PostAsync(uri, content).Result;
            var JSON = response.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(JSON);
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Choice
    {
        public string text { get; set; }
        public int index { get; set; }
        public object logprobs { get; set; }
        public string finish_reason { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public List<Choice> choices { get; set; }
        public Usage usage { get; set; }
    }

    public class Usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }

}
