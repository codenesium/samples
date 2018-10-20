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
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string ProductModel { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>f94b9f8c0076293ddc75b54077629816</Hash>
</Codenesium>*/