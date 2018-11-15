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
		public virtual decimal Amount { get; private set; }

		[MaxLength(90)]
		[Column("firstName")]
		public virtual string FirstName { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(90)]
		[Column("lastName")]
		public virtual string LastName { get; private set; }

		[Column("paymentTypeId")]
		public virtual int PaymentTypeId { get; private set; }

		[Column("petId")]
		public virtual int PetId { get; private set; }

		[MaxLength(10)]
		[Column("phone")]
		public virtual string Phone { get; private set; }

		[ForeignKey("PaymentTypeId")]
		public virtual PaymentType PaymentTypeNavigation { get; private set; }

		public void SetPaymentTypeNavigation(PaymentType item)
		{
			this.PaymentTypeNavigation = item;
		}

		[ForeignKey("PetId")]
		public virtual Pet PetNavigation { get; private set; }

		public void SetPetNavigation(Pet item)
		{
			this.PetNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>41f20f2330167eb36c838bd40581bdac</Hash>
</Codenesium>*/