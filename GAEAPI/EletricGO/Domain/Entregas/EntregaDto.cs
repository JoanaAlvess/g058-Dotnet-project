using System;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Domain.Entregas
{
    public class EntregaDto
    {
        public Guid Id { get; set; }
        public ArmazemId Armazem_Id { get; set; }
        public string DataEntrega { get; set; }
        public double MassaEntrega { get; set; }
        public int TempoColocar { get; set; }
        public int TempoRetirar { get; set; }

        public EntregaDto(Guid Id, ArmazemId armazemId, string dataEntrega, double massaEntrega, int tempoColocar, int tempoRetirar){
            this.Id = Id;
            this.Armazem_Id = armazemId;
            this.DataEntrega = dataEntrega;
            this.MassaEntrega = massaEntrega;
            this.TempoColocar = tempoColocar;
            this.TempoRetirar = tempoRetirar;
        } 
    }
} 