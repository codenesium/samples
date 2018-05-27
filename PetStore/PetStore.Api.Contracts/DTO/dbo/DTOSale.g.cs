using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class DTOSale: AbstractDTO
	{
		public DTOSale() : base()
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

		public decimal Amount { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public string LastName { get; set; }
		public int PaymentTypeId { get; set; }
		public int PetId { get; set; }
		public string Phone { get; set; }
	}
}

/*<Codenesium>
    <Hash>a6d02f3484e1d5e3ac4381ef7974c825</Hash>
</Codenesium>*/