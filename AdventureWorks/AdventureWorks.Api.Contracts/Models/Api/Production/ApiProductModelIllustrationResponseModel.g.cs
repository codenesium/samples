using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductModelIllustrationResponseModel: AbstractApiResponseModel
	{
		public ApiProductModelIllustrationResponseModel() : base()
		{}

		public void SetProperties(
			int illustrationID,
			DateTime modifiedDate,
			int productModelID)
		{
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductModelID = productModelID.ToInt();
		}

		public int IllustrationID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductModelID { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeIllustrationIDValue { get; set; } = true;

		public bool ShouldSerializeIllustrationID()
		{
			return this.ShouldSerializeIllustrationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue { get; set; } = true;

		public bool ShouldSerializeProductModelID()
		{
			return this.ShouldSerializeProductModelIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIllustrationIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductModelIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>cf6c146ff6642f6eef5e2bdfccf5888c</Hash>
</Codenesium>*/