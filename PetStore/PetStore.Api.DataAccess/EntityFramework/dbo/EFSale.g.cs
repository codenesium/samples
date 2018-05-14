using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetStoreNS.Api.DataAccess
{
	[Table("Sale", Schema="dbo")]
	public partial class Sale:AbstractEntityFrameworkPOCO
	{
		public Sale()
		{}

		public void SetProperties(
			int id,
			decimal amount,
			string firstName,
			string lastName,
			int paymentTypeId,
			int petId,
			string phone)
		{
			this.Amount = amount.ToDecimal();
			this.FirstName = firstName.ToString();
			this.Id = id.ToInt();
			this.LastName = lastName.ToString();
			this.PaymentTypeId = paymentTypeId.ToInt();
			this.PetId = petId.ToInt();
			this.Phone = phone.ToString();
		}

		[Column("amount", TypeName="money")]
		public decimal Amount { get; set; }

		[Column("firstName", TypeName="varchar(90)")]
		public string FirstName { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("lastName", TypeName="varchar(90)")]
		public string LastName { get; set; }

		[Column("paymentTypeId", TypeName="int")]
		public int PaymentTypeId { get; set; }

		[Column("petId", TypeName="int")]
		public int PetId { get; set; }

		[Column("phone", TypeName="varchar(10)")]
		public string Phone { get; set; }

		[ForeignKey("PaymentTypeId")]
		public virtual PaymentType PaymentType { get; set; }

		[ForeignKey("PetId")]
		public virtual Pet Pet { get; set; }
	}
}

/*<Codenesium>
    <Hash>55361ec44cd6b0d3530ee07af51a096f</Hash>
</Codenesium>*/