using System;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Entregas;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDDSample1.Domain.Users{

    public class User : Entity<UserId>, IAggregateRoot
    {
        [Required]
        public Nome _Nome { get; private set; }
        [Required]
        public Telefone _Telefone { get;  private set; }
        
        public Role _Role { get;  private set; }
        [Required]
        public Email _Email { get;  private set; }
        [Required]
        public Password _Password { get;  private set; }
        
        public bool Active{ get;  private set; }
        
        public User()
        {
             this.Active = true;
        }

        public User(string nome, string role, int telefone, string email, string password)
        {
            this.Id = new UserId(Guid.NewGuid());
            this._Nome = new Nome(nome);
            this._Role = new Role(role);
            this._Email = new Email(email);
            this._Password = new Password(password);
            this._Telefone = new Telefone(telefone);
            this.Active = true;
        } 

        public void ChangeNome(string nome)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the name to an inactive user.");
            this._Nome = new Nome(nome);
        }
          public void ChangeTelefone(int tele)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the telefone to an inactive user.");
            this._Telefone = new Telefone(tele);
        }
          public void ChangeRole(string role)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the role to an inactive user.");
            this._Role = new Role(role);
        }

        public void MarkAsInative()
        {
            this.Active = false;
        }

      
    }
}