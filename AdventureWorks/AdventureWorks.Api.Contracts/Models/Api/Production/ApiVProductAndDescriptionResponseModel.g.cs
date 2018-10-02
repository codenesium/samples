using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiVProductAndDescriptionResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string cultureID,
			string description,
			string name,
			int productID,
			string productModel)
		{
			this.CultureID = cultureID;
			this.Description = description;
			this.Name = name;
			this.ProductID = productID;
			this.ProductModel = productModel;
		}

		[JsonProperty]
		public string CultureID { get; private set; }

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public string ProductModel { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8ada9481aa01df61ef328353af81b53c</Hash>
</Codenesium>*/