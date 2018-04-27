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
			int illustrationID,
			DateTime modifiedDate,
			int productModelID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.IllustrationID = new ReferenceEntity<int>(illustrationID,
			                                               nameof(ApiResponse.Illustrations));
			this.ProductModelID = new ReferenceEntity<int>(productModelID,
			                                               nameof(ApiResponse.ProductModels));
		}

		public ReferenceEntity<int> IllustrationID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public ReferenceEntity<int> ProductModelID { get; set; }

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
    <Hash>98e477773f7f30ffae99f7e4b8099507</Hash>
</Codenesium>*/