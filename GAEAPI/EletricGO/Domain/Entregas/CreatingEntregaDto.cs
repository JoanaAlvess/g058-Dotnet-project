using DDDSample1.Domain.Armazens;

namespace DDDSample1.Domain.Entregas
{
    public class CreatingEntregaDto
    {
        public ArmazemId Armazem_Id { get; set; }
        public string DataEntrega { get; set; }
        public double MassaEntrega { get; set; }
        public int TempoColocar { get; set; }
        public int TempoRetirar { get; set; }

        public CreatingEntregaDto(string armazemId, string dataEntrega, double massaEntrega, int tempoColocar, int tempoRetirar)
        {
            this.Armazem_Id = new ArmazemId(armazemId);
            this.DataEntrega = dataEntrega;
            this.MassaEntrega = massaEntrega;
            this.TempoColocar = tempoColocar;
            this.TempoRetirar = tempoRetirar;
        }
    }
}