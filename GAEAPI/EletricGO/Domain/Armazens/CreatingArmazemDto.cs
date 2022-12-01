namespace DDDSample1.Domain.Armazens
{
    public class CreatingArmazemDto
    {
        //public String Id { get; set; }

        public string Designacao { get; set; }

        public string Endereco {get; set;}

        public string LojaId {get; set;}

        public string Municipio{get;set;}

        public double Latitude{get; set;}

        public double Longitude{get;set;}

        public CreatingArmazemDto(string Designacao,string Endereco,string LojaId,string Municipio,double Latitude,double Longitude){
            //this.Id = Id;
            this.Designacao = Designacao;
            this.Endereco = Endereco;
            this.LojaId = LojaId;
            this.Municipio = Municipio;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }
    
}