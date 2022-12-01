using System;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
namespace DDDSample1.Domain.Armazens
{
    public class Endereco : IValueObject
    {
        public Endereco(){

        }

        
        public string endereco {get; private set;}

       

        public Endereco(string endereco){
            setEndereco(endereco);
        }

         public void setEndereco(string endereco){
            if(String.IsNullOrEmpty(endereco)){
                throw new BusinessRuleValidationException("vazio");
            }
             if(!Regex.IsMatch(endereco,@"^[a-zA-Z0-9\s]+,[a-zA-Z0-9\s]+,([0-9]{4}-[0-9]{3})$")){
                throw new BusinessRuleValidationException("invalido");
            }
            this.endereco = endereco;
        }
    }
}
