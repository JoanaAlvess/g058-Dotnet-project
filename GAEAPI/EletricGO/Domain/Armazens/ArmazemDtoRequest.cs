using System;


namespace DDDSample1.Domain.Armazens
{
    public class ArmazemDtoRequest
    {
         public Guid id { get; set; }

        public string designacao { get; set; }

        public string endereco {get; set;}

        public string lojaId {get; set;}

        public string municipio{get;set;}

        public double latitude{get; set;}

        public double longitude{get;set;}
        public int cidadeNo{get;set;}

        public ArmazemDtoRequest(Guid id,string Designacao,string Endereco,string LojaId,string Municipio,double Latitude,double Longitude,int cidade){
            this.id = id;
            this.designacao = Designacao;
            this.endereco = Endereco;
            this.lojaId = LojaId;
            this.municipio = Municipio;
            this.latitude = Latitude;
            this.longitude = Longitude;
            this.cidadeNo = cidade;
        }
    }
}