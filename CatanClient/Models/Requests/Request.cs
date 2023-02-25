namespace CatanMAUI.Models.Requests
{
    public abstract class Request
    {
        protected string Name { get; set; }
        public HttpContent Content { get; set; }
        protected List<string> RequestParams { get; } = new();
        public string GenerateURI()
        {
            return $"http://localhost:8888/{Name}/{string.Join('/', RequestParams.Append("body"))}";
        }
        public virtual async Task SendRequest() { }
    }
}
