using System;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Domain.Users
{
     
public class Role : IValueObject
    {
        public Role(){

        }


       public string role {get; private set;}


        public Role(string role){
           setRole(role);
        }
         public void setRole(string role){
             if(role == null) {
                throw new BusinessRuleValidationException("invalido");
            }
            this.role = role;
        }
    }
}
