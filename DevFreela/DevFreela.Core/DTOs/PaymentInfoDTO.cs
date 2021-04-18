using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public int Id { get; private set; }
        public string CreditCardNumber { get; private set; }
        public string Cvv { get; private set; }
        public string ExpiresAt { get; private set; }
        public string FullName { get; private set; }
        public decimal TotalCoast { get; private set; }

        public PaymentInfoDTO(int id, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal totalCoast)
        {
            Id = id;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
            TotalCoast = totalCoast;
        }
    }
}
