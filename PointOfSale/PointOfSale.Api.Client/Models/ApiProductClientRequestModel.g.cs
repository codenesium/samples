using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PointOfSaleNS.Api.Client
{
	public partial class ApiProductClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiProductClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			bool active,
			string description,
			string name,
			decimal price,
			int quantity)
		{
			this.Active = active;
			this.Description = description;
			this.Name = name;
			this.Price = price;
			this.Quantity = quantity;
		}

		[JsonProperty]
		public bool Active { get; private set; } = default(bool);

		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public decimal Price { get; private set; } = default(decimal);

		[JsonProperty]
		public int Quantity { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>111dbe1556465e167847f7d3b06c717b</Hash>
</Codenesium>*/