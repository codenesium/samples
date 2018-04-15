using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductModelIllustration
	{
		public POCOProductModelIllustration()
		{}

		public POCOProductModelIllustration(
			int productModelID,
			int illustrationID,
			DateTime modifiedDate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.ProductModelID = new ReferenceEntity<int>(productModelID,
			                                               nameof(ApiResponse.ProductModels));
			this.IllustrationID = new ReferenceEntity<int>(illustrationID,
			                                               nameof(ApiResponse.Illustrations));
		}

		public ReferenceEntity<int> ProductModelID { get; set; }
		public ReferenceEntity<int> IllustrationID { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue { get; set; } = true;

		public bool ShouldSerializeProductModelID()
		{
			return this.ShouldSerializeProductModelIDValue;
		}

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

		public void DisableAllFields()
		{
			this.ShouldSerializeProductModelIDValue = false;
			this.ShouldSerializeIllustrationIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>aaf38a400a72a3814a068f3ad41603c3</Hash>
</Codenesium>*/