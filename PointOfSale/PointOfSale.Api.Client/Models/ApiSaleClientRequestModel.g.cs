using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PointOfSaleNS.Api.Client
{
	public partial class ApiSaleClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSaleClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int customerId,
			DateTime date)
		{
			this.CustomerId = customerId;
			this.Date = date;
		}

		[JsonProperty]
		public int CustomerId { get; private set; } = default(int);

		[JsonProperty]
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>f82369acf7f9c131a75ffc689305784e</Hash>
</Codenesium>*/