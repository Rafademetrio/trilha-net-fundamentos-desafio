using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private Dictionary<string, DateTime> veiculos = new Dictionary<string, DateTime>();

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
                veiculos.Add(carro, DateTime.Now);
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
                placa = carro;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Placa inválida, tente novamente. {ex.Message} ");
            }
           

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.Key.ToUpper() == placa.ToUpper()))
            {
                                
                //FEITO
                //Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                //int.TryParse(Console.ReadLine(), out int horas);

                // FOI RETIRADO O A SOLICITAÇÃO USUARIO, POIS IMPLEMEITEI PARA O SISTEMAS CADASTRAR A HORA DE ENTRADO PUXANDO PELO SISTEMA.
                // PARA FACILITAR OS TESTES IMPLEMENTEI A COBRANÇA POR SEGUNDOS.

                int.TryParse(veiculos[placa].ToString("ss"), out int horaDeEntrada);
                int.TryParse(DateTime.Now.ToString("ss"), out int horaDeSaida);


                int tempo = horaDeSaida - horaDeEntrada;
                decimal valorTotal = precoInicial + (precoPorHora * tempo); 
                

                
                
                Console.WriteLine($"O veículo {placa} entrou no estácionamento em {veiculos[placa]}!");
                Console.WriteLine($"E foi removido o preço total foi de: R$ {valorTotal}");
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
                int contador = veiculos.Count;
                foreach(var veiculo in veiculos)
                {
                    Console.WriteLine($"{contador+1}º Veiculo placa: {veiculo.Key} - hora de entrada: {veiculo.Value.ToString("HH:mm:ss")}");
                    contador++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
