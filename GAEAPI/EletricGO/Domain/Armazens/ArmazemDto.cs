using System;


namespace DDDSample1.Domain.Armazens
{
    public class ArmazemDto
    {
        public Guid Id { get; set; }

        public string Designacao { get; set; }

        public string Endereco {get; set;}

        public string LojaId {get; set;}

        public string Municipio{get;set;}

        public double Latitude{get; set;}

        public double Longitude{get;set;}

        public int CidadeNo{get;set;}

        public bool Active{get;set;}

        public double Altitude {get;set;}

        /*public ArmazemDto(Guid Id,string Designacao,string Endereco,string LojaId,string Municipio,double Latitude,double Longitude){
            this.Id = Id;
            this.Designacao = Designacao;
            this.Endereco = Endereco;
            this.LojaId = LojaId;
            this.Municipio = Municipio;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.CidadeNo = 0;
        }*/

          public ArmazemDto(Guid Id,string Designacao,string Endereco,string LojaId,string Municipio,double Latitude,double Longitude,int cidadeNo,bool active, double altitude){
            this.Id = Id;
            this.Designacao = Designacao;
            this.Endereco = Endereco;
            this.LojaId = LojaId;
            this.Municipio = Municipio;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.CidadeNo = cidadeNo;
            this.Active = active;
            this.Altitude = altitude;
        }
    }
}