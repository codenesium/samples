using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PointOfSaleNS.Api.Services
{
	public partial class ApiSaleServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSaleServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int CustomerId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>77a8793ed8a9b831c3a6c820e5d887d8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/