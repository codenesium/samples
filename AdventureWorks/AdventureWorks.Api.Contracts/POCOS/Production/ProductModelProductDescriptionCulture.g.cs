using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductModelProductDescriptionCulture
	{
		public POCOProductModelProductDescriptionCulture()
		{}

		public POCOProductModelProductDescriptionCulture(int productModelID,
		                                                 int productDescriptionID,
		                                                 string cultureID,
		                                                 DateTime modifiedDate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			ProductModelID = new ReferenceEntity<int>(productModelID,
			                                          "ProductModel");
			ProductDescriptionID = new ReferenceEntity<int>(productDescriptionID,
			                                                "ProductDescription");
			CultureID = new ReferenceEntity<string>(cultureID,
			                                        "Culture");
		}

		public ReferenceEntity<int>ProductModelID {get; set;}
		public ReferenceEntity<int>ProductDescriptionID {get; set;}
		public ReferenceEntity<string>CultureID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue {get; set;} = true;

		public bool ShouldSerializeProductModelID()
		{
			return ShouldSerializeProductModelIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductDescriptionIDValue {get; set;} = true;

		public bool ShouldSerializeProductDescriptionID()
		{
			return ShouldSerializeProductDescriptionIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCultureIDValue {get; set;} = true;

		public bool ShouldSerializeCultureID()
		{
			return ShouldSerializeCultureIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>d13c4c690771b64d161b69e7d2c06441</Hash>
</Codenesium>*/