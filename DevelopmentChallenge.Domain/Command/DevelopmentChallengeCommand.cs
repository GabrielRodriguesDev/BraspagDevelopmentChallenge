using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopmentChallenge.Domain.Notifications;

namespace DevelopmentChallenge.Domain.Command
{
    public class DevelopmentChallengeCommand : Notificable
    {
        public Decimal? Valor { get; set; }
        public String? Adquirente { get; set; } = null!;
        public String? Tipo { get; set; } = null!;
        public String? Bandeira { get; set; } = null!;

        public override void Validate()
        {
            if (this.Valor != null || this.Valor > 0)
            {
                if (this.Valor > 99999999.99m)
                {
                    this.AddNotification("Valor", $"Valor não pode ultrapassar de 99999999.99");
                }
            }

            if (String.IsNullOrEmpty(this.Adquirente))
            {
                this.AddNotification("Adquirente", "Informe o adquirente.");
            }

            if (String.IsNullOrEmpty(this.Tipo))
            {
                this.AddNotification("Tipo", "Informe o tipo da transação.");
            }
            else
            {
                if (!(this.Tipo == "Credito") || !(this.Tipo == "Debito"))
                {
                    this.AddNotification("Tipo", "Informe um tipo válido (Credito, Debito).");
                }
            }
            if (String.IsNullOrEmpty(this.Bandeira))
            {
                this.AddNotification("Bandeira", "Informe a bandeira.");
            }

        }
    }
}