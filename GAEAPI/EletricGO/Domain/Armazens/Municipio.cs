using System;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Domain.Armazens
{
     
public class Municipio : IValueObject
    {
        public Municipio(){

        }

        
        public string municipe {get; private set;}

        public Municipio(string municipe){
            setMunicipio(municipe);
        }
        public void setMunicipio(string municipe){

            if(String.IsNullOrEmpty(municipe)){

                throw new BusinessRuleValidationException("vazio");
            }

            this.municipe = municipe;

        }
       
    }
}
