using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductModelProductDescriptionCulture
	{
		public POCOProductModelProductDescriptionCulture()
		{}

		public POCOProductModelProductDescriptionCulture(
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID,
			int productModelID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.CultureID = new ReferenceEntity<string>(cultureID,
			                                             nameof(ApiResponse.Cultures));
			this.ProductDescriptionID = new ReferenceEntity<int>(productDescriptionID,
			                                                     nameof(ApiResponse.ProductDescriptions));
			this.ProductModelID = new ReferenceEntity<int>(productModelID,
			                                               nameof(ApiResponse.ProductModels));
		}

		public ReferenceEntity<string> CultureID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public ReferenceEntity<int> ProductDescriptionID { get; set; }
		public ReferenceEntity<int> ProductModelID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCultureIDValue { get; set; } = true;

		public bool ShouldSerializeCultureID()
		{
			return this.ShouldSerializeCultureIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductDescriptionIDValue { get; set; } = true;

		public bool ShouldSerializeProductDescriptionID()
		{
			return this.ShouldSerializeProductDescriptionIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue { get; set; } = true;

		public bool ShouldSerializeProductModelID()
		{
			return this.ShouldSerializeProductModelIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCultureIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductDescriptionIDValue = false;
			this.ShouldSerializeProductModelIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>430f7952f02b912722bfcca6ebe245a8</Hash>
</Codenesium>*/