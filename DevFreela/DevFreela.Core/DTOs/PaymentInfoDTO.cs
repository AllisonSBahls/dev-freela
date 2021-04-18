using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public int Id { get; private set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }

        public PaymentInfoDTO(int id, string creditCardNumber, string cvv, string expiresAt, string fullName)
        {
            Id = id;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
        }
    }
}
