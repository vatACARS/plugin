using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace vatACARS.Util
{
    public static class HttpClientUtils
    {
        private static string _baseUrl;
        private static Logger logger = new Logger("HttpClient");
        private static Random random = new Random();

        public static async Task DownloadFileTaskAsync(this HttpClient httpClient, string relativePath, string fileName, string baseUrlOverride = "")
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            if (string.IsNullOrWhiteSpace(_baseUrl) && !string.IsNullOrWhiteSpace(baseUrlOverride))
                throw new InvalidOperationException("Base URL is not set");

            if (relativePath == null)
                throw new ArgumentNullException(nameof(relativePath));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Invalid file name", nameof(fileName));

            int id = random.Next(1000, 9999);
            try
            {
                if (!string.IsNullOrEmpty(baseUrlOverride))
                    logger.Log($"({id}) DOWNLOADFILE [baseUrlOverride] {baseUrlOverride}{relativePath}");
                else
                    logger.Log($"({id}) DOWNLOADFILE (baseUrl){relativePath}");

                var fullUrl = new Uri(new Uri(!string.IsNullOrWhiteSpace(baseUrlOverride) ? baseUrlOverride : _baseUrl), relativePath);
                using (var s = await httpClient.GetStreamAsync(fullUrl))
                {
                    using (var fs = new FileStream(fileName, FileMode.CreateNew))
                    {
                        logger.Log($"({id}) Writing to file...");
                        await s.CopyToAsync(fs);
                        logger.Log($"({id}) Download completed.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                logger.Log($"({id}) HTTP request error: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                if (!httpClient.Timeout.Equals(Timeout.InfiniteTimeSpan))
                {
                    logger.Log($"({id}) HTTP request timeout: {ex.Message}");
                }
                else
                {
                    logger.Log($"({id}) Task was canceled: {ex.Message}");
                }
                throw;
            }
            catch (Exception ex)
            {
                logger.Log($"({id}) An error occured: {ex.Message}");
            }
        }

        public static async Task<string> GetStringTaskAsync(this HttpClient httpClient, string relativePath, string baseUrlOverride = "")
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            if (string.IsNullOrWhiteSpace(_baseUrl) && !string.IsNullOrWhiteSpace(baseUrlOverride))
                throw new InvalidOperationException("Base URL is not set");

            if (relativePath == null)
                throw new ArgumentNullException(nameof(relativePath));

            int id = random.Next(1000, 9999);
            try
            {
                if (!string.IsNullOrEmpty(baseUrlOverride))
                    logger.Log($"({id}) GET [baseUrlOverride] {baseUrlOverride}{relativePath}");
                else
                    logger.Log($"({id}) GET (baseUrl){relativePath}");

                var fullUrl = new Uri(new Uri(!string.IsNullOrWhiteSpace(baseUrlOverride) ? baseUrlOverride : _baseUrl), relativePath);
                HttpResponseMessage response = await httpClient.GetAsync(fullUrl);

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    logger.Log($"({id}) GET request failed: {ex.ToString()}");
                    return "";
                }

                logger.Log($"({id}) GET request completed.");
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                logger.Log($"({id}) HTTP request error: {ex.Message}");
                throw;
            }
            catch (TaskCanceledException ex)
            {
                if (!httpClient.Timeout.Equals(Timeout.InfiniteTimeSpan))
                {
                    logger.Log($"({id}) HTTP request timeout: {ex.Message}");
                }
                else
                {
                    logger.Log($"({id}) Task was canceled: {ex.Message}");
                }
                throw;
            }
            catch (Exception ex)
            {
                logger.Log($"({id}) An error occurred: {ex.Message}");
                throw;
            }
        }

        public static async Task<string> PostStringTaskAsync(this HttpClient httpClient, string relativePath, FormUrlEncodedContent content, string baseUrlOverride = "")
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            if (string.IsNullOrWhiteSpace(_baseUrl) && !string.IsNullOrWhiteSpace(baseUrlOverride))
                throw new InvalidOperationException("Base URL is not set");

            if (relativePath == null)
                throw new ArgumentNullException(nameof(relativePath));

            if (content == null)
                throw new ArgumentNullException(nameof(content));

            int id = random.Next(1000, 9999);
            try
            {
                if (!string.IsNullOrEmpty(baseUrlOverride))
                    logger.Log($"({id}) POST [baseUrlOverride] {baseUrlOverride}{relativePath}");
                else
                    logger.Log($"({id}) POST (baseUrl){relativePath}");

                var fullUrl = new Uri(new Uri(!string.IsNullOrWhiteSpace(baseUrlOverride) ? baseUrlOverride : _baseUrl), relativePath);
                HttpResponseMessage response = await httpClient.PostAsync(fullUrl, content);

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    logger.Log($"({id}) POST request failed: {ex.ToString()}");
                    return "";
                }

                logger.Log($"({id}) POST request completed.");

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                logger.Log($"({id}) HTTP request error: {ex.Message}");
                throw;
            }
            catch (TaskCanceledException ex)
            {
                if (!httpClient.Timeout.Equals(Timeout.InfiniteTimeSpan))
                {
                    logger.Log($"({id}) HTTP request timeout: {ex.Message}");
                }
                else
                {
                    logger.Log($"({id}) Task was canceled: {ex.Message}");
                }
                throw;
            }
            catch (Exception ex)
            {
                logger.Log($"({id}) An error occurred: {ex.Message}");
                throw;
            }
        }

        public static void SetBaseUrl(string baseUrl)
        {
            logger.Log($"baseUrl set to '{baseUrl}'");
            _baseUrl = baseUrl;
        }
    }
}