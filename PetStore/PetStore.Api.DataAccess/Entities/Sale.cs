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
			int id,
			decimal amount,
			string firstName,
			string lastName,
			int paymentTypeId,
			int petId,
			string phone)
		{
			this.Id = id;
			this.Amount = amount;
			this.FirstName = firstName;
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
		public virtual PaymentType PaymentTypeIdNavigation { get; private set; }

		public void SetPaymentTypeIdNavigation(PaymentType item)
		{
			this.PaymentTypeIdNavigation = item;
		}

		[ForeignKey("PetId")]
		public virtual Pet PetIdNavigation { get; private set; }

		public void SetPetIdNavigation(Pet item)
		{
			this.PetIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>88e10b5ada008c3a4ba2986f1c417b12</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/