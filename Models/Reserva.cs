namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        // Lista de hóspedes cadastrados na reserva
        public List<Pessoa> Hospedes { get; set; }

        // Suíte (quarto) que foi escolhida para essa reserva
        public Suite Suite { get; set; }

        // Quantidade de dias que a suíte foi reservada
        public int DiasReservados { get; set; }

        // Construtor padrão (vazio) — permite criar uma reserva sem passar nenhum dado inicial
        public Reserva() { }

        // Construtor que já define quantos dias a reserva vai durar
        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        // Método para cadastrar a suíte que foi escolhida para essa reserva
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite; // Armazena a suíte passada como parâmetro
        }

        // Método para cadastrar os hóspedes na reserva
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se o número de hóspedes cabe na suíte
            if (hospedes.Count <= Suite.Capacidade)
            {
                // Se couber, salva a lista de hóspedes
                Hospedes = hospedes;
            }
            else
            {
                // Se não couber, lança uma exceção dizendo que ultrapassou a capacidade
                throw new ArgumentException("Número de hóspedes excede a capacidade da suíte.");
            }
        }

        // Método que retorna quantas pessoas estão hospedadas nesta reserva
        public int ObterQuantidadeHospedes()
        {
            // Se a lista não for nula, retorna a quantidade de hóspedes
            // Caso contrário, retorna 0
            return Hospedes != null ? Hospedes.Count : 0;
        }

        // Método que calcula o valor total da diária da reserva
        public decimal CalcularValorDiaria()
        {
            // Calcula o valor total multiplicando os dias pela diária da suíte
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Se a reserva for de 10 dias ou mais, aplica um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= 0.90m; // Equivale a tirar 10% (ou multiplicar por 90%)
            }

            // Retorna o valor final com ou sem desconto
            return valor;
        }
    }
}
