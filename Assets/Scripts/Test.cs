using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System;
using UnityEngine;
using Newtonsoft.Json;
using System.Text;


public class Test : MonoBehaviour
{

    public List<Message> messages { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Send request!");

            callAPI();
        }
    }

    async void callAPI()
    {
        // Set up the request parameters
        var requestParams = new
        {
            model = "gpt-3.5-turbo",
            messages = new List<Message>()
            {
                new Message()
                {
                    role = "user",
                    content = "Hello!"
                }
            }
        };

        // Convert the request parameters to a JSON-encoded string
        var requestJson = JsonConvert.SerializeObject(requestParams);

        // Create a StringContent object with the request body


        // Set up the HTTP client with your API key
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer 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");

        // Set up the API endpoint URL and request parameters
        var apiUrl = "https://api.openai.com/v1/chat/completions";
        var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        Debug.Log(requestContent.ToString());

        // Make the API request
        var response = await client.PostAsync(apiUrl, requestContent);

        // Read the response and use the data as needed
        var responseContent = await response.Content.ReadAsStringAsync();
        Debug.Log(responseContent);
    }
}
public class Message
{
    public string role { get; set; }
    public string content { get; set; }
}