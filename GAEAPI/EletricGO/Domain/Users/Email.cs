using DDDSample1.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
namespace DDDSample1.Domain.Users
{
    
    public class Email : IValueObject{

        public string email {get; private set;}

        private Email(){}

        public Email (string email){
            if(String.IsNullOrWhiteSpace(email)) 
                throw new BusinessRuleValidationException("Need to introduce a Email");
            var emailTrimmed = email.Trim();
            var emailValidator = new EmailAddressAttribute();
            if(!emailValidator.IsValid(emailTrimmed)){
                throw new BusinessRuleValidationException($"Invalid Format for Email from input {email} !", nameof(email));
            }

            this.email = emailTrimmed;

        }
        
    }


}