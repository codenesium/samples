using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductModelProductDescriptionCulture: AbstractPOCO
	{
		public POCOProductModelProductDescriptionCulture() : base()
		{}

		public POCOProductModelProductDescriptionCulture(
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID,
			int productModelID)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.ProductModelID = productModelID.ToInt();
		}

		public string CultureID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductDescriptionID { get; set; }
		public int ProductModelID { get; set; }

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
    <Hash>5fac9a1706792e9dd69e80623762a356</Hash>
</Codenesium>*/