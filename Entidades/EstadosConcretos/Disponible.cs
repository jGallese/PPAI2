using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI.Entidades.EstadosConcretos
{
    public class Disponible : EstadoTurno
    {
        public Disponible()
        {

        }

        public override void registrarTurnoNoReservado() { }

        public override void reservar(DateTime fechaActual, CambioEstadoTurno cambioEActual, Turno turno) 
        {// CREA EL NUEVO ESTADO RESERVADO
         // LE SETEA fechaHoraHasta A cambioEActual.
         //crea el proximo cambio de estado, crearProxCambioEstado, y le setea la fechaHoraDesde, le asigna el estado Reservado
        }

        public override void registrarPeticionTurno() { }

        public override void cancelarTurnoPorMantCorrectivo() { }

    }
}
