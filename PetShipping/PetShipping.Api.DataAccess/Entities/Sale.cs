using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Sale", Schema="dbo")]
        public partial class Sale:AbstractEntity
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

                [Column("amount", TypeName="money")]
                public decimal Amount { get; private set; }

                [Column("clientId", TypeName="int")]
                public int ClientId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("note", TypeName="text(2147483647)")]
                public string Note { get; private set; }

                [Column("petId", TypeName="int")]
                public int PetId { get; private set; }

                [Column("saleDate", TypeName="datetime")]
                public DateTime SaleDate { get; private set; }

                [Column("salesPersonId", TypeName="int")]
                public int SalesPersonId { get; private set; }

                [ForeignKey("ClientId")]
                public virtual Client Client { get; set; }

                [ForeignKey("PetId")]
                public virtual Pet Pet { get; set; }
        }
}

/*<Codenesium>
    <Hash>3d5230d202a3f07e86aced9241b5c6d0</Hash>
</Codenesium>*/