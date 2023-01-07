using System;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
namespace DDDSample1.Domain.Users;

    public class Nome : IValueObject
    {
        public Nome(){

        }

        
        public string nome {get; private set;}

       

        public Nome(string nome){
            setNome(nome);
        }

         public void setNome(string nome){
            nome = nome.Trim();
            if(String.IsNullOrEmpty(nome)){
                throw new BusinessRuleValidationException("vazio");
            }
             if(!Regex.IsMatch(nome,@"^[0-9a-zA-Z ]+$")){
                throw new BusinessRuleValidationException("invalido");
            }
            this.nome = nome;
        }
       
    }

