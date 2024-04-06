using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace vatACARS.Util
{
    public static class HttpClientUtils
    {
        private static string _baseUrl;

        public static void SetBaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public static async Task<string> DownloadStringTaskAsync(this HttpClient httpClient, string relativePath)
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            if (string.IsNullOrWhiteSpace(_baseUrl))
                throw new InvalidOperationException("Base URL is not set");

            if (relativePath == null)
                throw new ArgumentNullException(nameof(relativePath));

            try
            {
                var fullUrl = new Uri(new Uri(_baseUrl), relativePath);
                HttpResponseMessage response = await httpClient.GetAsync(fullUrl);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public static async Task DownloadFileTaskAsync(this HttpClient httpClient, string relativePath, string fileName)
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            if (string.IsNullOrWhiteSpace(_baseUrl))
                throw new InvalidOperationException("Base URL is not set");

            if (relativePath == null)
                throw new ArgumentNullException(nameof(relativePath));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Invalid file name", nameof(fileName));

            try
            {
                var fullUrl = new Uri(new Uri(_baseUrl), relativePath);
                using (var s = await httpClient.GetStreamAsync(fullUrl))
                {
                    using (var fs = new FileStream(fileName, FileMode.CreateNew))
                    {
                        await s.CopyToAsync(fs);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request error: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
