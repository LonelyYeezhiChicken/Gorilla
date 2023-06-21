using System.Text;

namespace API.SDK
{
    public interface IChatGpt
    {
        Task<Result> CallChatGpt(string msg);
    }

    public class ChatGpt : IChatGpt
    {
        private readonly HttpClient _client;
        private readonly string _uri;
        private readonly string _model;

        public ChatGpt(IHttpClientFactory client, string uri,
            string model = "text-davinci-003")
        {
            _client = client.CreateClient();
            _uri = uri;
            _model = model;

            var apiKey1 = Environment.GetEnvironmentVariable("API_KEY")
                            ?? throw new NullReferenceException("沒付錢還想玩啊，乖乖付錢然後把環境變數設對吧!");

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey1}");
        }

        public async Task<Result> CallChatGpt(string msg)
        {
            var data = new
            {
                model = _model,
                prompt = msg,
                max_tokens = 4000,
                temperature = 0
            };

            var response = await _client.PostAsJsonAsync(_uri, data);
            response.EnsureSuccessStatusCode();

            return (await response.Content.ReadFromJsonAsync<Result>())!;
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
