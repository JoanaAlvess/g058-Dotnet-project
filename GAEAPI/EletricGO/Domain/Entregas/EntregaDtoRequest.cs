using System;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Domain.Entregas
{
    public class EntregaDtoRequest
    {
        public Guid id { get; set; }
        public string armazem { get; set; }
        public string data { get; set; }
        public double massa { get; set; }
        public int tempoc { get; set; }
        public int tempor { get; set; }

        public EntregaDtoRequest(Guid id, string armazemId, string dataEntrega, double massaEntrega, int tempoColocar, int tempoRetirar){
            this.id = id;
            this.armazem = armazemId;
            string dataEnt = dataEntrega.Replace("/","");
            this.data = dataEnt;
            this.massa = massaEntrega;
            this.tempoc = tempoColocar;
            this.tempor = tempoRetirar;
        } 
    }
} 