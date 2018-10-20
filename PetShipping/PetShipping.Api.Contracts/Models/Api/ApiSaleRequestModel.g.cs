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
		public decimal Amount { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int ClientId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PetId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime SaleDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int SalesPersonId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>ae92749d2b44ac376fb914cef069ea1b</Hash>
</Codenesium>*/