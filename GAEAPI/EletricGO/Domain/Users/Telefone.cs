using System;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Domain.Users
{

    
public class Telefone : IValueObject
    {
        public Telefone(){

        }
        public int telefone {get; private set;}

    
        public Telefone(int telefone){
            setTelefone(telefone);
        }

         public void setTelefone(int telefone){
            if(telefone.ToString().Length != 9){
                throw new BusinessRuleValidationException("Invalido");
            }
             
            this.telefone=telefone;
        }
        
        
    }
}
