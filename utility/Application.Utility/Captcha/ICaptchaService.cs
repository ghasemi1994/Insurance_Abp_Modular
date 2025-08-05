
using Application.Utility.Models;

namespace Application.Utility.Captcha;

public interface ICaptchaService
{
    Task<CaptchaResponse> GenerateCaptchaAsync(CancellationToken cancellationToken = default);
    Task<bool> VerifyCaptchaAsync(VerifyCaptchaRequest captcha, CancellationToken cancellationToken = default);
}
