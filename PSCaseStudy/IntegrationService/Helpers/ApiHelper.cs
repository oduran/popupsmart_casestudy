using PSCaseStudy.Datas.Entities;
using PSCaseStudy.Items;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationService.Helpers
{
    public class APIHelper : Singleton<APIHelper>
    {
        // Post - urle jsondata post eder
        public async Task<ResultItem> Post(string url, string jsonData)
        {
            try
            {
                System.Threading.Thread.Sleep(120);
                var data = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                var response = await client.PostAsync(url, data);
                var result = await response.Content.ReadAsStringAsync();

                return new ResultItem(true, result, "", response.StatusCode);
            }
            catch (Exception ex)
            {
                return new ResultItem(false, null, ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // GetWithCustomHeader - urle dictionary tipinde header ekleyerek giderek method çağırır
        public async Task<ResultItem> GetWithCustomHeader(string url, Dictionary<string,string> value)
        {
            try
            {
                System.Threading.Thread.Sleep(120);
                var client = new HttpClient();
                string res = string.Empty;

                HttpStatusCode httpStatusCode = HttpStatusCode.OK;

                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    foreach (var item in value)
                    {
                        requestMessage.Headers.Add(item.Key,item.Value);
                    }
                    var response = await client.SendAsync(requestMessage);
                    res = await response.Content.ReadAsStringAsync();
                    httpStatusCode = response.StatusCode;
                }

                return new ResultItem(true, res, string.Empty, httpStatusCode);
            }
            catch (Exception ex)
            {
                return new ResultItem(false, null, ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // GetActiveCampaignData - urle dictionary tipinde header ekleyerek giderek method çağırır
        public async Task<ResultItem> GetActiveCampaignData(string url, IntegrationItem item)
        {
            try
            {
                System.Threading.Thread.Sleep(120);
                //active campaing requestinde api-token header a yazmak gerekiyor.
                Dictionary<string, string> headerDict = new Dictionary<string, string>();
                headerDict.Add("Api-Token", item.ApiKey);
                var res =  await GetWithCustomHeader(item.ApiUrl, headerDict);
                return res;
            }
            catch (Exception ex)
            {
                return new ResultItem(false, null, ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // GetWithToken - urle token ile giderek method çağırır
        public async Task<ResultItem> GetWithToken(string url, string token)
        {
            try
            {
                System.Threading.Thread.Sleep(120);
                var client = new HttpClient();
                string res = string.Empty;

                HttpStatusCode httpStatusCode = HttpStatusCode.OK;

                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.SendAsync(requestMessage);
                    res = await response.Content.ReadAsStringAsync();
                    httpStatusCode = response.StatusCode;
                }

                return new ResultItem(true, res, string.Empty, httpStatusCode);
            }
            catch (Exception ex)
            {
                return new ResultItem(false, null, ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
