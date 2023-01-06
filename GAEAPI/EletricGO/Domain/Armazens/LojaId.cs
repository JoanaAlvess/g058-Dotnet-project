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

        
        public string lojaId {get; private set;}

    
        public LojaId(string lojaId){
            setLojasId(lojaId);
        }

         public void setLojasId(string lojaId){
            if(String.IsNullOrEmpty(lojaId)){
                throw new BusinessRuleValidationException("vazio");
            }
             if(lojaId.Length != 6){
                throw new BusinessRuleValidationException("invalido");
            }
            this.lojaId=lojaId;
        }
        
        
    }
}
