using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PointOfSaleNS.Api.Client
{
	public partial class ApiProductClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			bool active,
			string description,
			string name,
			decimal price,
			int quantity)
		{
			this.Id = id;
			this.Active = active;
			this.Description = description;
			this.Name = name;
			this.Price = price;
			this.Quantity = quantity;
		}

		[JsonProperty]
		public bool Active { get; private set; }

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public decimal Price { get; private set; }

		[JsonProperty]
		public int Quantity { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cd3c8d27eb8485f1257d5b4df0f580d8</Hash>
</Codenesium>*/