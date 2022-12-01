using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas
{
    public class DataEntrega : IValueObject
    {

        public string data { get; set;}
        public static readonly string Format = "yyyy/MM/dd";
        
        private DataEntrega(){
        }

        public DataEntrega(string dataEntrega){
            if(string.IsNullOrEmpty(dataEntrega)){
                throw new BusinessRuleValidationException("Data de entrega inválida (yyyy/MM/dd).");
            }
            try{
                DateOnly dt = DateOnly.ParseExact(dataEntrega, Format, System.Globalization.CultureInfo.InvariantCulture);
            } catch (FormatException){
                throw new BusinessRuleValidationException("Data de entrega inválida (yyyy/MM/dd).");
            }
            this.data = dataEntrega;
        }
    }
}