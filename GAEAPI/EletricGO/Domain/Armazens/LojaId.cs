using System;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Domain.Armazens
{

    
public class LojaId : IValueObject
    {
        public LojaId(){

        }

        
        public string id {get; private set;}

    
        public LojaId(string id){
            setLojasId(id);
        }

         public void setLojasId(string id){
            if(String.IsNullOrEmpty(id)){
                throw new BusinessRuleValidationException("vazio");
            }
             if(id.Length != 6){
                throw new BusinessRuleValidationException("invalido");
            }
            this.id=id;
        }
        
        
    }
}
