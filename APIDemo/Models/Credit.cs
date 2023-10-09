using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Cryptography.Pkcs;

namespace APIDemo.Models
{
    public class Credit
    {
        public int Id { get; }
        public int TimePeriod { get; }
        public int TotalPayments { get; }
        public float MaxAmount { get; }
        public float InterestAmount { get; }
        public string Description { get; }

        public int PaidPayments { get; set; }
        public float PaidAmount { get; set; }

        public Credit(int timePeriod, int totalPayments, float maxAmount, float interest, string description)
        {
            this.TimePeriod = timePeriod;
            this.TotalPayments = totalPayments;
            this.MaxAmount = maxAmount;
            this.Description = description;
            this.InterestAmount = interest;
            PaidAmount = 0;
            PaidPayments = 0;
            this.Id = 1;
        }
    }
}