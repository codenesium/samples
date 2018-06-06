using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetStoreNS.Api.DataAccess
{
	[Table("Sale", Schema="dbo")]
	public partial class Sale:AbstractEntity
	{
		public Sale()
		{}

		public void SetProperties(
			decimal amount,
			string firstName,
			int id,
			string lastName,
			int paymentTypeId,
			int petId,
			string phone)
		{
			this.Amount = amount.ToDecimal();
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.LastName = lastName;
			this.PaymentTypeId = paymentTypeId.ToInt();
			this.PetId = petId.ToInt();
			this.Phone = phone;
		}

		[Column("amount", TypeName="money")]
		public decimal Amount { get; private set; }

		[Column("firstName", TypeName="varchar(90)")]
		public string FirstName { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("lastName", TypeName="varchar(90)")]
		public string LastName { get; private set; }

		[Column("paymentTypeId", TypeName="int")]
		public int PaymentTypeId { get; private set; }

		[Column("petId", TypeName="int")]
		public int PetId { get; private set; }

		[Column("phone", TypeName="varchar(10)")]
		public string Phone { get; private set; }

		[ForeignKey("PaymentTypeId")]
		public virtual PaymentType PaymentType { get; set; }

		[ForeignKey("PetId")]
		public virtual Pet Pet { get; set; }
	}
}

/*<Codenesium>
    <Hash>75cc5de5b0fe3ca56c28820786effebc</Hash>
</Codenesium>*/