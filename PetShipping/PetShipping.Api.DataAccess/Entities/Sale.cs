using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Sale", Schema="dbo")]
        public partial class Sale : AbstractEntity
        {
                public Sale()
                {
                }

                public void SetProperties(
                        decimal amount,
                        int clientId,
                        int id,
                        string note,
                        int petId,
                        DateTime saleDate,
                        int salesPersonId)
                {
                        this.Amount = amount;
                        this.ClientId = clientId;
                        this.Id = id;
                        this.Note = note;
                        this.PetId = petId;
                        this.SaleDate = saleDate;
                        this.SalesPersonId = salesPersonId;
                }

                [Column("amount")]
                public decimal Amount { get; private set; }

                [Column("clientId")]
                public int ClientId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("note")]
                public string Note { get; private set; }

                [Column("petId")]
                public int PetId { get; private set; }

                [Column("saleDate")]
                public DateTime SaleDate { get; private set; }

                [Column("salesPersonId")]
                public int SalesPersonId { get; private set; }

                [ForeignKey("ClientId")]
                public virtual Client Client { get; set; }

                [ForeignKey("PetId")]
                public virtual Pet Pet { get; set; }
        }
}

/*<Codenesium>
    <Hash>de1f8ffed0f18a29769f35acaf0df356</Hash>
</Codenesium>*/