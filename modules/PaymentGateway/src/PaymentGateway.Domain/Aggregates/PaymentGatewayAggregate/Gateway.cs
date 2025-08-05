using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace PaymentGateway.Aggregates.PaymentGatewayAggregate;

public class Gateway : AggregateRoot<int>
{
    public string Name { get; protected set; }
    public string LogoUrl { get; protected set; }
    public string PaymentGatewayUrl { get; protected set; }
    public string CallBackUrl { get; protected set; }
    public string RedirectUrl { get; protected set; }
    public bool IsActive { get; protected set; }
    public bool SandBox { get; protected set; }
    public string AdditionalKey { get; protected set; }
    

    public Gateway()
    {

    }

    public Gateway(
        string name,
        string logoUrl,
        string callBackUrl,
        string redirectUrl,
        bool isActive,
        bool sandBox,
        string additionalKey)
    {
        if (string.IsNullOrEmpty(name))
            throw new NullReferenceException(name);

        if (string.IsNullOrEmpty(callBackUrl))
            throw new NullReferenceException(callBackUrl);

        if (string.IsNullOrEmpty(callBackUrl))
            throw new NullReferenceException(redirectUrl);


        Name = name;
        LogoUrl = logoUrl;
        CallBackUrl = callBackUrl;
        RedirectUrl = redirectUrl;
        IsActive = isActive;
        SandBox = sandBox;
        AdditionalKey = additionalKey;
    }



}
