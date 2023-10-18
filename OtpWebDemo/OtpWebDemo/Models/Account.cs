using System.ComponentModel.DataAnnotations;

namespace OtpWebDemo.Models
{
    public enum CardType
    {
        Visa, Master, Dina
    }

    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardType CardType { get; set; }
        public float MontlyFee { get; set; }
        public bool EBank { get; set; }

        public int UserId { get; set; }

    }
}
