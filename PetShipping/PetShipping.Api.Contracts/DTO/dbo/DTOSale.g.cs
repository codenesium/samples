using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOSale: AbstractDTO
	{
		public DTOSale() : base()
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

		public decimal Amount { get; set; }
		public int ClientId { get; set; }
		public int Id { get; set; }
		public string Note { get; set; }
		public int PetId { get; set; }
		public DateTime SaleDate { get; set; }
		public int SalesPersonId { get; set; }
	}
}

/*<Codenesium>
    <Hash>ce3582812468fd20895755b5b949ba9b</Hash>
</Codenesium>*/