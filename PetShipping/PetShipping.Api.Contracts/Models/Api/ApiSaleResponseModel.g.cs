using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiSaleResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			decimal amount,
			int clientId,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Id = id;
			this.Amount = amount;
			this.ClientId = clientId;
			this.Note = note;
			this.PetId = petId;
			this.SaleDate = saleDate;
			this.SalesPersonId = salesPersonId;

			this.ClientIdEntity = nameof(ApiResponse.Clients);
			this.PetIdEntity = nameof(ApiResponse.Pets);
		}

		[JsonProperty]
		public decimal Amount { get; private set; }

		[JsonProperty]
		public int ClientId { get; private set; }

		[JsonProperty]
		public string ClientIdEntity { get; set; }

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
    <Hash>0450f26c64d42d910bd3c6bb0faff77a</Hash>
</Codenesium>*/