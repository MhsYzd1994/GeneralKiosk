using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GeneralKiosk;
using Newtonsoft.Json;

public class LicenseManagementApi
{
    private HttpClient _httpClient;
    private string _baseUrl;

    public LicenseManagementApi()
    {

    }

    public async Task<string> Anything(string apiKey, string username, string password, string sysId, string productId)
    {

        _httpClient = new HttpClient();
        _baseUrl = "http://192.168.2.11:8000/en/api/";
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        CRC32 crc32 = new CRC32();


        string data = Program.ProcessorId.ToString().Substring(0, 4);
        byte[] bytes = Encoding.UTF8.GetBytes(data);
        uint checksum = crc32.ComputeChecksum(bytes);
        string x = crc32.ComputeChecksum(bytes).ToString().Substring(0, 2);
        var V = x + data + "-" + "N52J";
        //Console.WriteLine("Checksum (string): " + checksum.ToString("X"));



        var requestBody = new
        {
            API_KEY = apiKey,
            username = username,
            password = password,
            sysid = sysId,
            product_id = productId
        };

        var json = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // ارسال درخواست POST
        var response = await _httpClient.PostAsync(_baseUrl, content);

        // بررسی وضعیت پاسخ
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync(); // پاسخ موفق
        }
        else
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error: {response.StatusCode}, Message: {errorMessage}"); // مدیریت خطا
        }
    }
}
