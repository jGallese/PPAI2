using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades.EstadosConcretos
{
    public class Reservado : EstadoTurno
    {
        public Reservado()
        {
            Nombre = "Reservado";
            Descripcion = "Turno Reservado";
            oid = 2;
        }

        public override void cancelarTurno() { }

        public override void registrarTurnoNoUsado() { }

        public override void registrarInicioTurno() { }

        public override void cancelarTurnoPorMantCorrectivo() { }

    }
}
