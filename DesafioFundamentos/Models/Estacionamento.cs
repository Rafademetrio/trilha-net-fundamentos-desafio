using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            //FEITO
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string carro = Console.ReadLine().ToUpper();
            try
            {
                VerificarPlacar(carro);
                Console.WriteLine("Placa correta, carro incluido com sucesso. ");
                veiculos.Add(carro);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Placa inválida, tente novamente. {ex.Message} ");
            }
        }

        private bool VerificarPlacar(string placa)
        {
            string letrasPlaca = placa.Substring(0,3);
            string numerosPlaca = placa.Substring(4,4);

            if(Regex.IsMatch(letrasPlaca,@"^[A-Z]+$") && Regex.IsMatch(numerosPlaca,@"^[0-9]+$"))
            {
                return true;
            }else
            {
                return false;
            }


        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            //FEITO
            string carro = Console.ReadLine().ToUpper();
            string placa = "";
           try
            {
                VerificarPlacar(carro);
                Console.WriteLine("Placa correta, carro incluido com sucesso. ");
                placa = carro;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Placa inválida, tente novamente. {ex.Message} ");
            }
           

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                                
                //FEITO
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int.TryParse(Console.ReadLine(), out int horas);
                decimal valorTotal = precoInicial + (precoPorHora * horas); 
                

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                veiculos.Remove(placa);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine($"Temos {veiculos.Count} veículos estacionados e são:");
                //FEITO
                for(int i=0; i<veiculos.Count; i++)
                {
                    Console.WriteLine($"O {i+1}º : {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
