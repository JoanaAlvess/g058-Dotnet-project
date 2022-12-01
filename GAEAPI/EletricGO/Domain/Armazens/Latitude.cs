using System;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Domain.Armazens
{
    
public class Latitude : IValueObject
    {
        public Latitude(){

        }

       public double latitude {get; private set;}


        public Latitude(double latitude){
           this.latitude = latitude;
        }

         public void setLatitude(double latitude){
             if(latitude < -90 && latitude > 90){
                throw new BusinessRuleValidationException("invalido");
            }
            this.latitude = latitude;
        }
    }
}
