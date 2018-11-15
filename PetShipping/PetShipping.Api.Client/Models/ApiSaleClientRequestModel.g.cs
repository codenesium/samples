using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiSaleClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSaleClientRequestModel()
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

		[JsonProperty]
		public decimal Amount { get; private set; } = default(decimal);

		[JsonProperty]
		public int CutomerId { get; private set; } = default(int);

		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[JsonProperty]
		public int PetId { get; private set; }

		[JsonProperty]
		public DateTime SaleDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int SalesPersonId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>4993cb42f2336a5936e630f48ccfe843</Hash>
</Codenesium>*/