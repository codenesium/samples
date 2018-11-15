using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiSaleServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSaleServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal amount,
			int cutomerId,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Amount = amount;
			this.CutomerId = cutomerId;
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
		public int CutomerId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PetId { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime SaleDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int SalesPersonId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>a9223e6bdb8545869fb4f45696da1311</Hash>
</Codenesium>*/