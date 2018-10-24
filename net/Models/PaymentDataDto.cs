using System;

namespace net
{
    public class PaymentDataDto
    {
        public string Amount { get; set; }
        public string Description { get; set; }
        public string FailUrl { get; set; }
        public string Merchant { get; set; }
        public string OrderId { get; set; }
        public string SecretKey { get; set; }
        public string SuccessUrl { get; set; }
        public string Testing { get; set; }
        public string UnixTimestamp { get; set; }
        public string ReceiptContact { get; set; }

    }
}
