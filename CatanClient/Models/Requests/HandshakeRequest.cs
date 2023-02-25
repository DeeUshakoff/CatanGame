namespace CatanMAUI.Models.Requests
{
    public class HandshakeRequest :Request 
    {
        public HandshakeRequest()
        {
            Name = "Handshake";
        }

        public static new async Task SendRequest()
        {
            var request = new HandshakeRequest();
            request.RequestParams.Add(Client.Id.ToString());

            request.Content = new StringContent("Try to connect");

            var response = await Client.SendRequestGetResponeAsync(request, HttpMethod.Get);

            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Server response if not OK", "Close");
            }

            var responseBody = await Client.ReadResponseBodyAsync(response);
            //await App.Current.MainPage.DisplayAlert("Result", responseBody, "Close");
        }
    }
}
