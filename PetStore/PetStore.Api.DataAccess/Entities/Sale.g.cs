using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetStoreNS.Api.DataAccess
{
	[Table("Sale", Schema="dbo")]
	public partial class Sale : AbstractEntity
	{
		public Sale()
		{
		}

		public virtual void SetProperties(
			decimal amount,
			string firstName,
			int id,
			string lastName,
			int paymentTypeId,
			int petId,
			string phone)
		{
			this.Amount = amount;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.PaymentTypeId = paymentTypeId;
			this.PetId = petId;
			this.Phone = phone;
		}

		[Column("amount")]
		public decimal Amount { get; private set; }

		[MaxLength(90)]
		[Column("firstName")]
		public string FirstName { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(90)]
		[Column("lastName")]
		public string LastName { get; private set; }

		[Column("paymentTypeId")]
		public int PaymentTypeId { get; private set; }

		[Column("petId")]
		public int PetId { get; private set; }

		[MaxLength(10)]
		[Column("phone")]
		public string Phone { get; private set; }

		[ForeignKey("PaymentTypeId")]
		public virtual PaymentType PaymentTypeNavigation { get; private set; }

		[ForeignKey("PetId")]
		public virtual Pet PetNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1571b1fadae767a1223ca6f9c6c26697</Hash>
</Codenesium>*/