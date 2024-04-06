using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace vatACARS.Util
{
    public static class HttpClientUtils
    {
        public static async Task<string> DownloadStringTaskAsync(this HttpClient httpClient, Uri uri)
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
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

        public static async Task DownloadFileTaskAsync(this HttpClient httpClient, Uri uri, string fileName)
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Invalid file name", nameof(fileName));

            try
            {
                using (var s = await httpClient.GetStreamAsync(uri))
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
