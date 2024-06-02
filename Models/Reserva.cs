using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospedagemHotelaria.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            //Aqui verifico e retorno uma exceção caso o número de pessoas seja maior que a capacidade do quarto.
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("O número de pessoas é maior que a capacidade do quarto.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = 0;
            valor = DiasReservados * Suite.ValorDiaria;


            //Aqui estou aplicando desconto de 10% caso o cliente permaneca 10 dias ou mais.
            if (DiasReservados >= 10)
            {
                decimal desconto = 0;
                desconto = valor * 0.10M;
                valor = valor - desconto;
            }

            return valor;
        }
    }
}