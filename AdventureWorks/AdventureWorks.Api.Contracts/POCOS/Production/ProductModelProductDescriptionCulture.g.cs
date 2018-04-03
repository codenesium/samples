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
			this.ProductModelID = productModelID.ToInt();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductModelID {get; set;}
		public int ProductDescriptionID {get; set;}
		public string CultureID {get; set;}
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
    <Hash>ade8a63a70eb3fe9a7b3fe953b7e14ee</Hash>
</Codenesium>*/