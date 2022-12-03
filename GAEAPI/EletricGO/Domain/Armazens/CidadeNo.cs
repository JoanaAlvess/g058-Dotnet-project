using System;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Domain.Armazens
{

    
public class CidadeNo : IValueObject
    {
        public CidadeNo(){

        }
        public int no {get; private set;}

    
        public CidadeNo(int no){
            setLojasId(no);
        }

         public void setLojasId(int no){
            if(no<0){
                throw new BusinessRuleValidationException("vazio");
            }
             
            this.no=no;
        }
        
        
    }
}
