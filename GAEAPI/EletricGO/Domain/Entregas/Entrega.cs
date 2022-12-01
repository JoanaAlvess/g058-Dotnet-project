using System;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Domain.Entregas{

    public class Entrega : Entity<EntregaId>, IAggregateRoot
    {
        public ArmazemId _ArmazemId { get; private set; }
        public DataEntrega _DataEntrega { get; private set; }
        public MassaEntrega _MassaEntrega { get;  private set; }
        public TempoColocar _TempoColocar { get;  private set; }
        public TempoRetirar _TempoRetirar { get;  private set; }

        public bool Active{ get;  private set; }

        public Entrega()
        {
             this.Active = true;
        }

        public Entrega(ArmazemId armazemId, string dataEntrega, double massaEntrega, int tempoColocar, int tempoRetirar)
        {
            this.Id = new EntregaId(Guid.NewGuid());
            this._ArmazemId = armazemId;
            this._DataEntrega = new DataEntrega(dataEntrega);
            this._MassaEntrega = new MassaEntrega(massaEntrega);
            this._TempoColocar = new TempoColocar(tempoColocar);
            this._TempoRetirar = new TempoRetirar(tempoRetirar);
            this.Active = true;
        }

        public void ChangeArmazemEntrega(ArmazemId armazemId)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the warehouse id to an inactive delivery.");
            this._ArmazemId = armazemId;
        }
        
        public void ChangeDataEntrega(string dataEntrega)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the delivery date to an inactive delivery.");
            this._DataEntrega = new DataEntrega(dataEntrega);
        }

        public void ChangeMassaEntrega(double massaEntrega)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the weight to an inactive delivery.");
            this._MassaEntrega = new MassaEntrega(massaEntrega);
        }

        public void ChangeTempoColocar(int tempoColocar)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the loading date to an inactive delivery.");
            this._TempoColocar = new TempoColocar(tempoColocar);
        }

        public void ChangeTempoRetirar(int tempoRetirar)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the unloading date to an inactive delivery.");
            this._TempoRetirar = new TempoRetirar(tempoRetirar);
        }

        public void MarkAsInative()
        {
            this.Active = false;
        }
    }
} 