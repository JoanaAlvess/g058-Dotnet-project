using System;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Domain.Armazens
{
     
public class Longitude : IValueObject
    {
        public Longitude(){

        }

       public double longitude {get; private set;}


        public Longitude(double longitude){
           setLongitude(longitude);
        }

        public void setLongitude(double longitude){
             if(longitude < -180 && longitude > 180){
                throw new BusinessRuleValidationException("invalido");
            }
            this.longitude = longitude;
        }
    }
}
