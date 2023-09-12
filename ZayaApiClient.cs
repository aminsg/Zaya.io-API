using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

/// <summary>
/// please read the documentation https://github.com/aminsg/Zaya.io-API"
/// </summary>
public class ZayaApiClient
{
    #region main variable
    private static HttpClient client = new HttpClient();
    private static string baseUrl = "https://zaya.io/api/v1/";
    #endregion
    /// <summary>
    /// Create a binding header to work with zaya
    /// To start you need consteruct this function at first
    /// </summary>
    /// <param name="token">Get the token from "https://zaya.io/developers/api"</param>
    /// <returns>return error if token isnt valid</returns>
    public static string Connect(string token)
    {
        try
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            return string.Empty;
        }
        catch
        {
            return "The token is invalid, please read the documentation https://github.com/aminsg/Zaya.io-API";
        }
    }
    public static class Account
    {
        /// <summary>
        /// Get a json file of your account details
        /// </summary>
        /// <returns>Json string</returns>
        public static string Details()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}account").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }

    }
    public static class URL
    {
        /// <summary>
        /// get a json file from details of all of url in you account
        /// </summary>
        /// <returns>Json string</returns>
        public static string AllUrl()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}links").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;

            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Create a shortened URL
        /// </summary>
        /// <param name="url">url for shorten</param>
        /// <returns>Shortened URL</returns>
        public static string CreateUrl(string url)
        {
            try
            {
                // Check if the URL doesn't start with "https://" or "http://"
                if (!url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) &&
                    !url.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                {
                    // If it doesn't, add "https://"
                    url = "https://" + url;
                }

                var content = new FormUrlEncodedContent(new[]
                {
            new KeyValuePair<string, string>("url", url)
        });

                HttpResponseMessage response = client.PostAsync($"{baseUrl}links", content).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Get Details of a URL by id
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string DetailUrl(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}links/{id}").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Update a URL by id
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string UpdateUrl(int id, string url)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("url", url)
            });

                HttpResponseMessage response = client.PutAsync($"{baseUrl}links/{id}", content).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Delete a URL by id
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string DeleteUrl(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync($"{baseUrl}links/{id}").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
    }
    public static class Domain
    {
        /// <summary>
        /// Get list of all domains
        /// </summary>
        /// <returns>Json string</returns>
        public static string AllDomain()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}domains").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Create a new Domain (for premium users)
        /// </summary>
        /// <param name="domain">domain name</param>
        /// <returns>Json string</returns>
        public static string CreateDomain(string domain)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("name", domain)
            });

                HttpResponseMessage response = client.PostAsync($"{baseUrl}domains", content).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Get Details of a domain by id
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string DetailsDomain(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}domains/{id}").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Update a domain by id
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string UpdateDomain(int id, string domain)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("name", domain)
            });

                HttpResponseMessage response = client.PutAsync($"{baseUrl}domains/{id}", content).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Delete a domain by id
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string DeleteDomain(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync($"{baseUrl}domains/{id}").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
    }
    public static class topics
    {
        /// <summary>
        /// Get List of topics 
        /// </summary>
        /// <returns>Json string</returns>
        public static string Topics()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}spaces").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Build the topic
        /// </summary>
        /// <param name="name">Name for topic</param>
        /// <param name="color">Color HeX code for example #ff0000</param>
        /// <returns>Json string</returns>
        public static string CreateTopic(string name, string color)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("name", name),
                new KeyValuePair<string, string>("color", color)
            });

                HttpResponseMessage response = client.PostAsync($"{baseUrl}spaces", content).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Get Deatils of a Topic by id
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string DetailsTopic(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}spaces/{id}").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Update a Topic
        /// </summary>
        /// <param name="id">ID number</param>
        /// <param name="name">New name</param>
        /// <returns>Json string</returns>
        public static string UpdateTopic(int id, string name)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("name", name)
            });

                HttpResponseMessage response = client.PutAsync($"{baseUrl}spaces/{id}", content).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Delete a Topic
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string DeleteTopic(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync($"{baseUrl}spaces/{id}").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
    }
    public static class stats
    {
        /// <summary>
        /// Get Stats of URL by ID
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string Stats(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}stats/{id}/total").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Get Clicks of URL by ID
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string Clicks(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}stats/{id}/clicks").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Get Referrers of URL by ID
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string Referrers(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}stats/{id}/referrers").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// List of countries that have opened the link
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string Countries(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}stats/{id}/countries").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// List of languages that have opened the link
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string Languages(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}stats/{id}/languages").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// Get the list of browsers that have opened the URL
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string Browsers(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}stats/{id}/browsers").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// List of devices that have opened the link
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string Devices(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}stats/{id}/devices").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
        /// <summary>
        /// The list of operating systems that have opened the link
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Json string</returns>
        public static string OperatingSystems(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}stats/{id}/operating-systems").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException Err)
            {
                return Err.Message;
            }
        }
    }
}
