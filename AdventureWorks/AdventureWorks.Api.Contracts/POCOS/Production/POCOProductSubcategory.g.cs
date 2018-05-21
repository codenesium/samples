using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductSubcategory: AbstractPOCO
	{
		public POCOProductSubcategory() : base()
		{}

		public POCOProductSubcategory(
			DateTime modifiedDate,
			string name,
			int productCategoryID,
			int productSubcategoryID,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ProductCategoryID = productCategoryID.ToInt();
			this.ProductSubcategoryID = productSubcategoryID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public int ProductCategoryID { get; set; }
		public int ProductSubcategoryID { get; set; }
		public Guid Rowguid { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductCategoryIDValue { get; set; } = true;

		public bool ShouldSerializeProductCategoryID()
		{
			return this.ShouldSerializeProductCategoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductSubcategoryIDValue { get; set; } = true;

		public bool ShouldSerializeProductSubcategoryID()
		{
			return this.ShouldSerializeProductSubcategoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeProductCategoryIDValue = false;
			this.ShouldSerializeProductSubcategoryIDValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>ad05920f1de86ad0b94120ff93f75ebb</Hash>
</Codenesium>*/