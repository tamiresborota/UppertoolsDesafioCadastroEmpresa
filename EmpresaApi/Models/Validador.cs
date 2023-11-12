namespace EmpresaApi.Models
{
    public class Validador
    {
        // Método para validar um CNPJ
        public static bool ValidarCnpj(string cnpj)
        {
            int[] PesoPrimeiroBloco = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] PesoSegundoBloco = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Verifica se o CNPJ possui o tamanho correto
            if (cnpj.Length != 14)
            {
                throw new InvalidCastException("CNPJ inválido. Insira um CNPJ válido.");
            }
            else
            {
                // Verifica se todos os caracteres do CNPJ são dígitos
                for (int i = 0; i < cnpj.Length; i++)
                {
                    if (!char.IsDigit(cnpj[i]))

                    {
                        throw new InvalidCastException("CNPJ inválido. Todos os caracteres devem ser dígitos.");
                    }
                }
            }
            // Somatório para gerar o valor para verificar o CNPJ
            int soma = 0;

            for (int i = 0; i < PesoPrimeiroBloco.Length; i++)
            {
                soma += int.Parse(cnpj[i].ToString()) * PesoPrimeiroBloco[i];
            }

            int resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }

            else
            {
                resto = 11 - resto;
            }
            string digito1 = resto.ToString();

            // Verificação do primeiro dígito verificador
            if (digito1 != cnpj[12].ToString())
            {
                throw new InvalidCastException("CNPJ inválido.");
            }

            soma = 0;
            for (int i = 0; i < PesoSegundoBloco.Length; i++)
            {
                soma += int.Parse(cnpj[i].ToString()) * PesoSegundoBloco[i];
            }


            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }

            else
            {
                resto = 11 - resto;
            }

            string digito = digito1 + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
