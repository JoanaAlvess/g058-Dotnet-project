using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;

using DDDSample1.Utils;
using System;
using Newtonsoft.Json;

namespace DDDSample1.Domain.Users
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _repo;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repo)
        {
            
            this._unitOfWork = unitOfWork;

            this._repo = repo;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<UserDto> listDto = list.ConvertAll<UserDto>(user =>
                new UserDto(user.Id.AsGuid(), user._Nome.nome, user._Role.role, user._Telefone.telefone, user._Email.email, user._Password.password));

            return listDto;
        }

        

        public async Task<UserDto> GetByIdAsync(UserId id)
        {
            var user = await this._repo.GetByIdAsync(id);

            if (user == null)
                return null;

            return new UserDto(user.Id.AsGuid(), user._Nome.nome, user._Role.role, user._Telefone.telefone, user._Email.email, user._Password.password);
        }

        public async Task<UserDto> RegisterUser(CreatingUserDto dto)
        {
            var user = new User(dto.Nome, dto.Role, dto.Telefone, dto.Email, dto.Password);
            
            await this._repo.AddAsync(user);
            await this._unitOfWork.CommitAsync();

            return new UserDto(user.Id.AsGuid(), user._Nome.nome, user._Role.role, user._Telefone.telefone, user._Email.email, user._Password.password);
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = (await this._repo.GetUserByEmail(email));

            if (user == null)
                return null;
            
            return new UserDto(user.Id.AsGuid(), user._Nome.nome, user._Role.role, user._Telefone.telefone, user._Email.email, user._Password.password);
        }

        public async Task<Role> GetUserRolebyEmail(string email)
        {
            var role = (await this._repo.GetUserRolebyEmail(email));

            if (role == null)
                return null;
            
            return role;
        }

        public async Task<UserDto> LoginUser(Login loginData)
        {
            
            var user = await this._repo.GetUserByEmail(loginData.Email);
            //List<User> list = await this._repo.GetAllAsync();

           
            
            if (user == null)
                return null;
            
            if (!SecretHasher.Verify(loginData.Password, user._Password.password))
                return null;
            
            return new UserDto (user.Id.AsGuid(), user._Nome.nome, user._Role.role, user._Telefone.telefone, user._Email.email, user._Password.password)
                ;
        }
         public async Task<UserDto> InactivateAsync(string email)
        {
            var user = (await this._repo.GetUserByEmail(email));

            if (user == null)
                return null;   

            user.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new UserDto(user.Id.AsGuid(), user._Nome.nome,user._Role.role,user._Telefone.telefone,user._Email.email,user._Password.password);
        }

         public async Task<UserDto> DeleteAsync(string email)
        {
            var arm = (await this._repo.GetUserByEmail(email));

            if (arm == null)
                return null;   

            
            if (arm.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active armazem.");
            
            this._repo.Remove(arm);
            await this._unitOfWork.CommitAsync();

            return new UserDto(arm.Id.AsGuid(), arm._Nome.nome,arm._Role.role,arm._Telefone.telefone,arm._Email.email,arm._Password.password);

        }

    }

        
    }
