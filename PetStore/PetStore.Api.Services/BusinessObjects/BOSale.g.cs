using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
{
	public partial class BOSale:AbstractBusinessObject
	{
		public BOSale() : base()
		{}

		public void SetProperties(int id,
		                          decimal amount,
		                          string firstName,
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

		public decimal Amount { get; private set; }
		public string FirstName { get; private set; }
		public int Id { get; private set; }
		public string LastName { get; private set; }
		public int PaymentTypeId { get; private set; }
		public int PetId { get; private set; }
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>897ff1eea89289469f42f2e1d30f932a</Hash>
</Codenesium>*/