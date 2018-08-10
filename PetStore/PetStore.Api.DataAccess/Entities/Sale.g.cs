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

		[Column("firstName")]
		public string FirstName { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("lastName")]
		public string LastName { get; private set; }

		[Column("paymentTypeId")]
		public int PaymentTypeId { get; private set; }

		[Column("petId")]
		public int PetId { get; private set; }

		[Column("phone")]
		public string Phone { get; private set; }

		[ForeignKey("PaymentTypeId")]
		public virtual PaymentType PaymentTypeNavigation { get; private set; }

		[ForeignKey("PetId")]
		public virtual Pet PetNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a25ff864d7e3bfb55a4a6bfec788eab7</Hash>
</Codenesium>*/