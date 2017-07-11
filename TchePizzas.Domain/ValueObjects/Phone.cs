using System.Text.RegularExpressions;
using FluentValidator;

namespace TchePizzas.Domain.ValueObjects
{
    public class Phone : Notifiable
    {
        public Phone(string number)
        {
            Number = number;

            //Passo 1. Verifa se o formato do telefone é válido
            if (!ValidatePhone(number))
                //Passo 2. Adiciona notificação se formato do telefone não for válido
                AddNotification("Phone", "Formato do telefone é inválido.");
        }

        public string Number{get;private set;}

        public bool ValidatePhone(string number){

            //Valida formato Celular -> (XX) XXXXX-XXXX | Residencial -> (XX) XXXX-XXXX
            Regex rx = new Regex(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$");

            if (rx.IsMatch(number))
                return true;
                
            return false;
        }
    }
}
