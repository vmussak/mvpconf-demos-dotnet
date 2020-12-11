using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MvpConfDemos
{
    public static class IteracoesInstancias
    {
        public static void VerificarSeEmailValido()
        {
            var listaDeEmails = BuscarEmails();

            var emailRegex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            foreach (var email in listaDeEmails)
            {
                var regex = new Regex(emailRegex, RegexOptions.IgnoreCase);
                var oEmailEstaValido = regex.IsMatch(email);
                if (oEmailEstaValido)
                {
                    //Alguma operacão aqui...
                }
            }
        }

        public static void VerificarSeEmailValidoRapidao()
        {
            var listaDeEmails = BuscarEmails();

            var emailRegex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(emailRegex, RegexOptions.IgnoreCase);

            foreach (var email in listaDeEmails)
            {
                var oEmailEstaValido = regex.IsMatch(email);
                if (oEmailEstaValido)
                {
                    //Alguma operacão aqui...
                }
            }
        }

        private static IEnumerable<string> BuscarEmails()
        {
            for (int i = 0; i < 500_000; i++)
                yield return $"email{i}@outlook.com.br";
        }
    }
}
