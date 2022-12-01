using System;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Domain.Armazens
{
     
public class Designacao : IValueObject
    {
        public Designacao(){

        }

       public string designacao {get; private set;}


        public Designacao(string designacao){
           setDesignacao(designacao);
        }
         public void setDesignacao(string designacao){
             if(designacao.Length > 50){
                throw new BusinessRuleValidationException("invalido");
            }
            this.designacao = designacao;
        }
    }
}
