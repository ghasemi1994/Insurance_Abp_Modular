
namespace Application.Utility.Models;

public class VerifyCaptchaRequest
{
    /// <summary>
    /// این مقدار زمان ساختن کپچا برگشت داده می شود
    /// </summary>
    public string CaptchaKey { get; set; }
    /// <summary>
    /// جواب کپچا
    /// </summary>
    public string CaptchaCode { get; set; }
}
