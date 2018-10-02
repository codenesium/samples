using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiSaleRequestModel : AbstractApiRequestModel
	{
		public ApiSaleRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal amount,
			int clientId,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Amount = amount;
			this.ClientId = clientId;
			this.Note = note;
			this.PetId = petId;
			this.SaleDate = saleDate;
			this.SalesPersonId = salesPersonId;
		}

		[Required]
		[JsonProperty]
		public decimal Amount { get; private set; }

		[Required]
		[JsonProperty]
		public int ClientId { get; private set; }

		[Required]
		[JsonProperty]
		public string Note { get; private set; }

		[Required]
		[JsonProperty]
		public int PetId { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime SaleDate { get; private set; }

		[Required]
		[JsonProperty]
		public int SalesPersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1f759cbd6094832fe0b25b626612f620</Hash>
</Codenesium>*/