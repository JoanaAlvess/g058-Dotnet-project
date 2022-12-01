using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas
{

    
public class MassaEntrega : IValueObject
    {
        public double massa {get; set;}

        private MassaEntrega(){

        }

        public MassaEntrega(double massaEntrega){
            if(massaEntrega < 0 ){
                throw new BusinessRuleValidationException("Massa de entrega inválida.");
            }
            this.massa = massaEntrega;
        }
    }
}