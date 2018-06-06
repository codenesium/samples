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
		{}

		public void SetProperties(
			decimal amount,
			int clientId,
			int id,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Amount = amount.ToDecimal();
			this.ClientId = clientId.ToInt();
			this.Id = id.ToInt();
			this.Note = note;
			this.PetId = petId.ToInt();
			this.SaleDate = saleDate.ToDateTime();
			this.SalesPersonId = salesPersonId.ToInt();
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
    <Hash>73d0ca002d0f19254dd261a31bea0386</Hash>
</Codenesium>*/