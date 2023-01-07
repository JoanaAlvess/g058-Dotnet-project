using System;

namespace DDDSample1.Domain.Users
{
    public class UserDto{

        public Guid Id {get; set;}
        public string Nome {get;set;}
        public string Role {get;set;}
        public int Telefone {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        
        public UserDto(Guid Id, string nome, string role, int telefone, string email, string password){
            this.Id = Id ;
            this.Nome = nome;
            this.Role = role;
            this.Telefone = telefone;
            this.Email = email;
            this.Password = password;
        }
    }
}