using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas
{
    
public class TempoColocar : IValueObject
    {
        public int _tempoColocar {get; set;}
        private TempoColocar(){

        }

        public TempoColocar(int tempoColocar){
            if(tempoColocar < 0){
                throw new BusinessRuleValidationException("Tempo de colocação inválido (insira em minutos).");
            }
            this._tempoColocar = tempoColocar;
        }
    }
}
