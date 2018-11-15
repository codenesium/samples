using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiSaleClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			decimal amount,
			int cutomerId,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Id = id;
			this.Amount = amount;
			this.CutomerId = cutomerId;
			this.Note = note;
			this.PetId = petId;
			this.SaleDate = saleDate;
			this.SalesPersonId = salesPersonId;

			this.PetIdEntity = nameof(ApiResponse.Pets);
		}

		[JsonProperty]
		public decimal Amount { get; private set; }

		[JsonProperty]
		public int CutomerId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public int PetId { get; private set; }

		[JsonProperty]
		public string PetIdEntity { get; set; }

		[JsonProperty]
		public DateTime SaleDate { get; private set; }

		[JsonProperty]
		public int SalesPersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>494ce6cec8e61a58e2ed5fa9b8fc18a5</Hash>
</Codenesium>*/