

using Application.Utility.DistributedCache;
using Application.Utility.Models;
using ImageMagick;
using ImageMagick.Drawing;
using Newtonsoft.Json;


namespace Application.Utility.Captcha;

internal class CaptchaService : ICaptchaService
{
    public static CacheKey CaptchaCacheKey => new("Cache.Customer.Captcha.{0}");

    private readonly IStaticCacheManagerService _staticCacheManagerService;
    public CaptchaService(IStaticCacheManagerService staticCacheManagerService)
    {
        _staticCacheManagerService = staticCacheManagerService;
    }

    public async Task<CaptchaResponse> GenerateCaptchaAsync(CancellationToken cancellationToken = default)
    {

        var chars = Guid.NewGuid().ToString("N");

        chars = chars.Substring(chars.Length - 9, 8);

        string question = "";
        string answer = "";

        byte[] captchaImage;

        (question, answer) = GenerateCaptcha();
        captchaImage =  await GenerateCaptchaGiftAsync(question, false, cancellationToken);

        var captchaKey = Guid.NewGuid().ToString();

        string jsn = JsonConvert.SerializeObject(
            new CaptchaInCache
            {
                CaptchaKey = captchaKey,
                CaptchaCode = answer,      
            });


        var key = _staticCacheManagerService.PrepareKeyForShortTermCache(CaptchaCacheKey, captchaKey);

        await _staticCacheManagerService.SetAsync(key, jsn);

        return new CaptchaResponse { CaptchaKey = captchaKey, Image = Convert.ToBase64String(captchaImage) };
    }

    public async Task<bool> VerifyCaptchaAsync(VerifyCaptchaRequest captcha, CancellationToken cancellationToken = default)
    {
        string cInMemory = string.Empty;

        var key = _staticCacheManagerService.PrepareKeyForShortTermCache(CaptchaCacheKey, captcha.CaptchaKey);
        (cInMemory) =  await _staticCacheManagerService.GetAsync(key, () => "");

        if (string.IsNullOrEmpty(cInMemory))
        {
            return false;
        }

        var captchaInMemory = JsonConvert.DeserializeObject<CaptchaInCache>(cInMemory);

        if (captchaInMemory?.CaptchaKey == captcha.CaptchaKey && captchaInMemory?.CaptchaCode.ToLower() == captcha.CaptchaCode.ToLower())
        {
            return true;
        }

        return false;
    }

    #region Utilities
    private async Task<byte[]> GenerateCaptchaGiftAsync(string captchaCode, bool isGift, CancellationToken ct)
    {

        var rnd = new Random();
        var collection = new MagickImageCollection();
        int width = 133;
        int height = 34;


        var image = new MagickImage(MagickColors.Transparent, (uint)width, (uint)height) { Format = MagickFormat.Gif };


        //background random

        var bgColor = new MagickColor((byte)rnd.Next(180, 256), (byte)rnd.Next(180, 256), (byte)rnd.Next(180, 256));

        new Drawables().FillColor(bgColor).Rectangle(0, 0, width, height).Draw(image);

        //create circle

        for (int j = 0; j < 5; j++)
        {
            var circleColor = new MagickColor((byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256));

            int cx = rnd.Next(width);
            int cy = rnd.Next(height);
            int radius = rnd.Next(5, 15);

            new Drawables().StrokeColor(circleColor).FillColor(MagickColors.None).StrokeWidth(1.5).Ellipse(cx, cy, radius, radius, 0, 360).Draw(image);
        }

        //create code

        int x = 10;
        foreach (var ch in captchaCode)
        {
            var charImg = new MagickImage(MagickColors.Transparent, 40, 40);
            var charColor = new MagickColor((byte)rnd.Next(0, 60), (byte)rnd.Next(0, 60), (byte)rnd.Next(0, 60));
            var drow = new Drawables().Font("Arial").FontPointSize(22).StrokeColor(MagickColors.DarkGray).StrokeWidth(0.8).FillColor(charColor).Text(5, 24, ch.ToString());
            drow.Draw(charImg);

            charImg.Rotate(rnd.Next(-10, 10));
            charImg.AddNoise(NoiseType.Gaussian);

            image.Composite(charImg, x, 0, CompositeOperator.Over);

            x += 18;// 15 + rnd.Next(-1, 2);//فاصله نامنظم
        }

        image.AnimationDelay = 100;
        collection.Add(image);


        collection.Optimize();

        using var ms = new MemoryStream();

        collection.Write(ms);

        return await Task.FromResult(ms.ToArray());


    }
    private (string question, string answer) GenerateCaptcha()
    {

        Random random = new Random();
        int randomNumber = random.Next(10000, 100000);

        string question = randomNumber.ToString();
        string answer = randomNumber.ToString();

        return (question, answer);

    }
    #endregion
}



public class CaptchaInCache
{
    public string CaptchaKey { get; set; }
    public string CaptchaCode { get; set; }
}