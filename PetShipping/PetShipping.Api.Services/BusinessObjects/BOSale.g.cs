using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOSale:AbstractBusinessObject
	{
		public BOSale() : base()
		{}

		public void SetProperties(int id,
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
			this.Note = note;
			this.PetId = petId.ToInt();
			this.SaleDate = saleDate.ToDateTime();
			this.SalesPersonId = salesPersonId.ToInt();
		}

		public decimal Amount { get; private set; }
		public int ClientId { get; private set; }
		public int Id { get; private set; }
		public string Note { get; private set; }
		public int PetId { get; private set; }
		public DateTime SaleDate { get; private set; }
		public int SalesPersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e65a49b954dcd143b708aab15fa695b5</Hash>
</Codenesium>*/