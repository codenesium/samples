using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Sale", Schema="dbo")]
	public partial class Sale:AbstractEntityFrameworkPOCO
	{
		public Sale()
		{}

		public void SetProperties(
			int id,
			decimal amount,
			int clientId,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Amount = amount.ToDecimal();
			this.ClientId = clientId.ToInt();
			this.Id = id.ToInt();
			this.Note = note.ToString();
			this.PetId = petId.ToInt();
			this.SaleDate = saleDate.ToDateTime();
			this.SalesPersonId = salesPersonId.ToInt();
		}

		[Column("amount", TypeName="money")]
		public decimal Amount { get; set; }

		[Column("clientId", TypeName="int")]
		public int ClientId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("note", TypeName="text(2147483647)")]
		public string Note { get; set; }

		[Column("petId", TypeName="int")]
		public int PetId { get; set; }

		[Column("saleDate", TypeName="datetime")]
		public DateTime SaleDate { get; set; }

		[Column("salesPersonId", TypeName="int")]
		public int SalesPersonId { get; set; }

		[ForeignKey("ClientId")]
		public virtual Client Client { get; set; }

		[ForeignKey("PetId")]
		public virtual Pet Pet { get; set; }
	}
}

/*<Codenesium>
    <Hash>b9657577c3674ea7370b82fd22d9967a</Hash>
</Codenesium>*/