using PPAI.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades.EstadosConcretos
{
    public class Disponible : EstadoTurno
    {
        public Disponible()
        {
            Nombre = "Disponible";
            oid = 3;
            Descripcion = "Turno Disponible";

        }

        public override void registrarTurnoNoReservado() { }

        public override void reservarTurno(DateTime fechaActual, Turno turno) 
        {// CREA EL NUEVO ESTADO RESERVADO
         // LE SETEA fechaHoraHasta A cambioEActual.
         //crea el proximo cambio de estado, crearProxCambioEstado, y le setea la fechaHoraDesde, le asigna el estado Reservado

            List<CambioEstadoTurno> listaCambiosTurno= turno.getCambiosEstadoDeTurno();

            CambioEstadoTurno actual = new CambioEstadoTurno();

            foreach (CambioEstadoTurno cEstado in listaCambiosTurno)
            {
                if (cEstado.EsActual())
                {
                    actual = cEstado;
                    break;
                }
                
            }
            actual.setFechaHasta(fechaActual);

            Reservado nuevoEstado = crearProxEstado();

            CambioEstadoTurno nuevoCambioEstado = crearProxCambioEstado(fechaActual, nuevoEstado);

            turno.setEstado(nuevoEstado);
            turno.agregarCambioEstado(nuevoCambioEstado);

            bool res = AD_Turnos.reservarTurnoTransaccion(turno, nuevoCambioEstado, this.oid, fechaActual);

            if (res)
            {
                MessageBox.Show("Todo ok perro");
            }
        }

        public override void registrarPeticionTurno() { }

        public override void cancelarTurnoPorMantCorrectivo() { }

        public override Reservado crearProxEstado()
        {
            Reservado nuevo = new Reservado();
            
            return nuevo;
        }

        public override CambioEstadoTurno crearProxCambioEstado(DateTime fechaHoraDesde, EstadoTurno estado)
        {
            CambioEstadoTurno cEturno = new CambioEstadoTurno(fechaHoraDesde, estado);
            return cEturno;

        }


    }
}
