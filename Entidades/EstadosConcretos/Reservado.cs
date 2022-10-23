using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI.Entidades.EstadosConcretos
{
    public class Reservado : EstadoTurno
    {
        public Reservado()
        {
        }

        public void cancelarTurno() { }

        public void registrarTurnoNoUsado() { }

        public void registrarInicioDeTurno() { }

        public void cancelarTurnoPorMantCorrectivo() { }

    }
}
