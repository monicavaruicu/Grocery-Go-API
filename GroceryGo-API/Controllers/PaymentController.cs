using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;

[Route("payment")]
[ApiController]
public class PaymentController : ControllerBase
{
    [HttpPost("create-checkout-session")]
    public IActionResult CreateCheckoutSession([FromBody] PaymentRequest request)
    {
        if (request == null || request.Amount <= 0)
        {
            return BadRequest("Invalid payment request. Make sure the amount is greater than zero.");
        }

        StripeConfiguration.ApiKey = "sk_test_51QgQviHGj8pDXLfAaFLc5vacFur6nRCMiutnU6mc3ocfCugSx3UbSlmvFafWz2c0dYDXISS4BLiGoN3D3qTfzFzb00EcetO0rL";

        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "ron",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Total to Pay"
                        },
                        UnitAmount = request.Amount
                    },
                    Quantity = 1
                }
            },
            Mode = "payment",
            SuccessUrl = "http://localhost:4200/payment/success",
            CancelUrl = "http://localhost:4200/payment/cancel"
        };

        var service = new SessionService();
        Session session = service.Create(options);

        return Ok(new { id = session.Id });
    }
}

public class PaymentRequest
{
    public int Amount { get; set; }
}
