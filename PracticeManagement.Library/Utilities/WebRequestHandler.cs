using Newtonsoft.Json;
using PracticeManagement.Library.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PracticeManagement.Library.Utilities
{
    public class WebRequestHandler
    {
        private string host = "localhost";
        private string port = "5151";
        private HttpClient webClient { get; }
        //private HttpProject Project { get; }
        //private HttpBill Bill { get; }
        public WebRequestHandler()
        {
            webClient = new HttpClient();
/*            Project = new HttpProject();
            Bill = new HttpBill();*/
        }
        public async Task<string> Get(string url)
        {
            var fullUrl = $"http://{host}:{port}{url}";
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client
                        .GetStringAsync(fullUrl)
                        .ConfigureAwait(false);
                    return response;
                }
            }
            catch (Exception e)
            {

            }


            return null;
        }

        public async Task<string> Delete(string url)
        {
            var fullUrl = $"http://{host}:{port}{url}";
            try
            {
                using (var client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Delete, fullUrl))
                    {
                        using (var response = await client
                                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                                .ConfigureAwait(false))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            return "ERROR";
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }


            return null;
        }

        public async Task<string> Post(string url, object obj)
        {
            var fullUrl = $"http://{host}:{port}{url}";
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, fullUrl))
                {
                    var json = JsonConvert.SerializeObject(obj);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;
                        using (var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            return "ERROR";
                        }
                    }
                }
            }

        }
         
        /*    +++++++++++++++ Project Section    +++++++++++++    *//*
        public async Task<string> GetProject(string url)
        {
            var fullUrl = $"http://{host}:{port}{url}";
            try
            {
                using (var project = new HttpProject())
                {
                    var response = await project
                        .GetStringAsync(fullUrl)
                        .ConfigureAwait(false);
                    return response;
                }
            }
            catch (Exception e)
            {

            }


            return null;
        }

        public async Task<string> DeleteProject(string url)
        {
            var fullUrl = $"http://{host}:{port}{url}";
            try
            {
                using (var project = new HttpProject())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Delete, fullUrl))
                    {
                        using (var response = await project
                                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                                .ConfigureAwait(false))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            return "ERROR";
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }


            return null;
        }

        public async Task<string> PostProject(string url, object obj)
        {
            var fullUrl = $"http://{host}:{port}{url}";
            using (var project = new HttpProject())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, fullUrl))
                {
                    var json = JsonConvert.SerializeObject(obj);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;
                        using (var response = await project
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            return "ERROR";
                        }
                    }
                }
            }

        }

        *//*    +++++++++++++++   Bill Section    +++++++++++++    *//*

        public async Task<string> GetBill(string url)
        {
            var fullUrl = $"http://{host}:{port}{url}";
            try
            {
                using (var bill = new HttpBill())
                {
                    var response = await bill
                        .GetStringAsync(fullUrl)
                        .ConfigureAwait(false);
                    return response;
                }
            }
            catch (Exception e)
            {

            }


            return null;
        }

        public async Task<string> DeleteBill(string url)
        {
            var fullUrl = $"http://{host}:{port}{url}";
            try
            {
                using (var bill = new HttpBill())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Delete, fullUrl))
                    {
                        using (var response = await bill
                                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                                .ConfigureAwait(false))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            return "ERROR";
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }


            return null;
        }

        public async Task<string> PostBill(string url, object obj)
        {
            var fullUrl = $"http://{host}:{port}{url}";
            using (var bill = new HttpBill())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, fullUrl))
                {
                    var json = JsonConvert.SerializeObject(obj);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;
                        using (var response = await bill
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            return "ERROR";
                        }
                    }
                }
            }

        }*/

        

    }
}