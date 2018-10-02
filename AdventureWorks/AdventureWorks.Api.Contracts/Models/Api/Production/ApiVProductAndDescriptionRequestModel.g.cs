using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiVProductAndDescriptionRequestModel : AbstractApiRequestModel
	{
		public ApiVProductAndDescriptionRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string description,
			string name,
			int productID,
			string productModel)
		{
			this.Description = description;
			this.Name = name;
			this.ProductID = productID;
			this.ProductModel = productModel;
		}

		[Required]
		[JsonProperty]
		public string Description { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; }

		[Required]
		[JsonProperty]
		public string ProductModel { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3c69713a93935985d1e4b5bb4f0dda6d</Hash>
</Codenesium>*/