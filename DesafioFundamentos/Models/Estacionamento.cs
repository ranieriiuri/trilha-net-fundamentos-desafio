using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0M;
        private decimal precoPorHora = 0M;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // DONE: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            
            // Método p validar entrada de modelo da placa
            static bool ValidacaoModeloPlaca(string numeroPlaca)
            {
            // Usei Regex p definir o formato desejado "XXX-00X0"
                Regex regex = new Regex(@"^[A-Z]{3}-\d{2}[A-Z]\d{1}$");
                return regex.IsMatch(numeroPlaca.ToUpper());
            }
            
            while(true)
            {
                Console.WriteLine("Digite a placa do veículo para cadastrar ou 'Enter' 2x para voltar ao menu principal:\n(Siga o modelo 'XXX-00X0' -->  3 letras, 1 caractere '-' , 2 números, 1 letra, 1 número --> Em maiúsculas ou minúsculas!)");
                string adicionarVeículo = Console.ReadLine();

                //Se for inserido valor vazio retorna ao menu
                if(string.IsNullOrEmpty(adicionarVeículo))
                {
                    break;
                }
                //Se o método de validação do modelo da placa for satisfeito adic. à lista
                if(ValidacaoModeloPlaca(adicionarVeículo))
                {
                    veiculos.Add(adicionarVeículo.ToUpper());
                    break;
                }
                else
                {
                    Console.WriteLine($"\nFormato inserido é inválido. Siga o modelo proposto!\n");
                }
            }

            Console.WriteLine("\nPlaca registrada com sucesso!\n");

        }

        public void RemoverVeiculo()
        {
            while(true)
            {   
                //Utilizando 'if' aninhados p fazer as verificações necessárias

                // Se já tiver veículos cadastrados...
                if(veiculos.Any())
                {
                     Console.WriteLine("\nDigite a placa do veículo para remover ou pressione 'Enter' 2x p voltar:");

                    // Pedir para o usuário digitar a placa e armazenar na variável placa
                    string placa = Console.ReadLine();
                    
                    // Se inserir dados vazios, volta ao menu principal
                    if(string.IsNullOrEmpty(placa))
                    {
                        break;
                    }
                
                    //Caso o dado inserido bata com alguma placa no cadastro...
                    else if (veiculos.Any(x => x == placa.ToUpper()))
                    {
                        int horas = 0;
                        decimal valorTotal = 0M;
                        
                        // DONE: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                        Console.WriteLine("\nDigite a quantidade de horas que o veículo permaneceu estacionado:");
                        string inserirHorasEstacionado = Console.ReadLine();
                        
                        // DONE: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                        //Utilizando o 'TryParse' p fazer a conversão de string p int
                        if (int.TryParse(inserirHorasEstacionado, out int horasEstacionado))
                        {
                            horas = horasEstacionado;
                            valorTotal = (precoInicial + precoPorHora) * horas;
                            
                            // DONE: Remover a placa digitada da lista de veículos
                            veiculos.Remove(placa.ToUpper());
                            //Apresentando resultado do método,o valor a ser pago e saindo do laço
                            Console.WriteLine($"\nO veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}!\nFavor efetuar o pagamento ao caixa, obrigado!\n");
                            break;
                           
                        }
                        else
                        {
                            Console.WriteLine("\nDado inserido sobre horas de estacionamento do veículo é inválido, informe as horas em números inteiros!\n(Ex.: 1, 2, 3...)");
                        }
                    
                      
                    }
                    else
                    {
                        Console.WriteLine("\nDesculpe, esse veículo não foi cadastrado. Confira se digitou a placa corretamente");
                    }
                }
                
                //Senão...
                else
                {
                    Console.WriteLine("Não temos veículos cadastrados, no momento.\n");
                    break;
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos constantes em nossos registros atuais são:\n");
                
                // DONE: Realizar um laço de repetição, exibindo os veículos estacionados
                foreach(var veiculo in veiculos)
                {
                    Console.WriteLine($"- Placa: [{veiculo}] está estacionado em nossas dependências -");
                }
            }
            else
            {
                Console.WriteLine("\nNão há veículos cadastrados.");
            }
        }
    }
}