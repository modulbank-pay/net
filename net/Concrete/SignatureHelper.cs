using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace net.Concrete
{
    public static class SignatureHelper
    {
        public static string GetSignature(PaymentDataDto dto)
        {
            var
                values =
                    $@"amount={Getval(dto.Amount)}&description={Getval(dto.Description)}&fail_url={Getval(dto.FailUrl)}&merchant={Getval(dto.Merchant)}&order_id={Getval(dto.OrderId)}&receipt_contact={Getval(dto.ReceiptContact)}&success_url={Getval(dto.SuccessUrl)}&testing={Getval(dto.Testing)}&unix_timestamp={Getval(dto.UnixTimestamp)}";

            return SHA1(dto.SecretKey + SHA1(dto.SecretKey + values).ToLower()).ToLower();
        }

        private static string Getval(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }


        private static string SHA1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
