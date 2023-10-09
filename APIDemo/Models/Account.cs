using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Models
{
    public class Account
    {
        public float MonthlyFee { get; }
        public CardType Card { get; }
        public bool EnabledEBank { get; }
        public string? Description { get; }
        public double Amount { get; set; }
        public AccountType Type { get; }

        public Account(float fee, CardType card, AccountType type, string? description = null, bool eBank = true)
        {
            this.EnabledEBank = eBank;
            this.MonthlyFee = fee;
            this.Description = description;
            this.Card = card;
            this.Type = type;
        }
    }
}

