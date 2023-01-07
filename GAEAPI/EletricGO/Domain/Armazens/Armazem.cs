using System;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Entregas;
using System.Collections.Generic;

namespace DDDSample1.Domain.Armazens{

    public class Armazem : Entity<ArmazemId>, IAggregateRoot
    {
        public Longitude _Longitude { get; private set; }
        public LojaId _LojaId { get;  private set; }
        public Municipio _Municipio { get;  private set; }
        public Latitude _Latitude { get;  private set; }
        public Endereco _Endereco { get;  private set; }
        public Designacao _Designacao { get;  private set; }

        public CidadeNo _CidadeNo {get; private set;}

        public ICollection<Entrega> Entregas { get; set; }
        public bool Active{ get;  private set; }

        public Altitude _Altitude { get; private set; }

        public Armazem()
        {
             this.Active = true;
        }

       /* public Armazem(double longitude, double latitude, string endereco, string designacao, string municipio, string lojaId)
        {
            this.Id = new ArmazemId(Guid.NewGuid());
            this._Longitude = new Longitude(longitude);
            this._Latitude = new Latitude(latitude);
            this._Municipio = new Municipio(municipio);
            this._LojaId = new LojaId(lojaId);
            this._Designacao = new Designacao(designacao);
            this._Endereco = new Endereco(endereco); 
            this._CidadeNo = new CidadeNo(0);
        } */
        public Armazem(double longitude, double latitude, string endereco, string designacao, string municipio, string lojaId,int cidadeNo, double altitude)
        {
            this.Id = new ArmazemId(Guid.NewGuid());
            this._Longitude = new Longitude(longitude);
            this._Latitude = new Latitude(latitude);
            this._Municipio = new Municipio(municipio);
            this._LojaId = new LojaId(lojaId);
            this._Designacao = new Designacao(designacao);
            this._Endereco = new Endereco(endereco); 
            this._CidadeNo = new CidadeNo(cidadeNo);
            this._Altitude = new Altitude(altitude);
            this.Active = true;
        } 

        public void ChangeLongitude(double longitude)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the longitude to an inactive armazem.");
            this._Longitude = new Longitude(longitude);
        }

        public void ChangeLatitude(double latitude)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the latitude to an inactive armazem.");
            this._Latitude = new Latitude(latitude);
        }

        public void ChangeMunicipio(string municipio)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the municipio to an inactive armazem.");
            this._Municipio = new Municipio(municipio);
        }

        public void ChangeLojaId(string lojaId)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the lojaId to an inactive armazem.");
            this._LojaId = new LojaId(lojaId);
        }

        public void ChangeDesignacao(string designacao)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the designacao to an inactive armazem.");
            this._Designacao = new Designacao(designacao);
        }

        public void ChangeEndereco(string endereco)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the endereco to an inactive armazem.");
            this._Endereco = new Endereco(endereco);
        }

        public void ChangeAltitude(double altitude)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the altitude to an inactive armazem.");
            this._Altitude = new Altitude(altitude);
        }

        public void MarkAsInative()
        {
            this.Active = false;
        }

      
    }
}