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
			int productModelID,
			int productDescriptionID,
			string cultureID,
			DateTime modifiedDate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.ProductModelID = new ReferenceEntity<int>(productModelID,
			                                               nameof(ApiResponse.ProductModels));
			this.ProductDescriptionID = new ReferenceEntity<int>(productDescriptionID,
			                                                     nameof(ApiResponse.ProductDescriptions));
			this.CultureID = new ReferenceEntity<string>(cultureID,
			                                             nameof(ApiResponse.Cultures));
		}

		public ReferenceEntity<int> ProductModelID { get; set; }
		public ReferenceEntity<int> ProductDescriptionID { get; set; }
		public ReferenceEntity<string> CultureID { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue { get; set; } = true;

		public bool ShouldSerializeProductModelID()
		{
			return this.ShouldSerializeProductModelIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductDescriptionIDValue { get; set; } = true;

		public bool ShouldSerializeProductDescriptionID()
		{
			return this.ShouldSerializeProductDescriptionIDValue;
		}

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

		public void DisableAllFields()
		{
			this.ShouldSerializeProductModelIDValue = false;
			this.ShouldSerializeProductDescriptionIDValue = false;
			this.ShouldSerializeCultureIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>1faacc213abeecfc40af15d40cd3e59c</Hash>
</Codenesium>*/