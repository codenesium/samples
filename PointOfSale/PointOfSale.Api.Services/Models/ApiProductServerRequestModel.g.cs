using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PointOfSaleNS.Api.Services
{
	public partial class ApiProductServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiProductServerRequestModel()
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

		[Required]
		[JsonProperty]
		public bool Active { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public decimal Price { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int Quantity { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>a674ad4983513bf267e9dc8fca9607d5</Hash>
</Codenesium>*/