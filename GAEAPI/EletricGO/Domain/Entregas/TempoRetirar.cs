using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas
{
    
public class TempoRetirar : IValueObject{

        public int _tempoRetirar {get; set;}
    
        private TempoRetirar(){

        }

        public TempoRetirar(int tempoRetirar){
            if(tempoRetirar < 0){
                throw new BusinessRuleValidationException("Tempo de retirar inválido (insira em minutos).");
            }
            this._tempoRetirar = tempoRetirar;
        }
    }
}
