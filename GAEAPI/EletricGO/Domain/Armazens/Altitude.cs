using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazens
{

public class Altitude : IValueObject
    {
        public Altitude(){

        }
        public double altitude {get; private set;}

        public Altitude(double altitude){
            setAltitude(altitude);
        }

        public void setAltitude(double altitude){
            if(altitude < -500){
                throw new BusinessRuleValidationException("Altitude inválida.");
            }
            this.altitude = altitude;
        }
    }
}