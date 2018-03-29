using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductSubcategory
	{
		public POCOProductSubcategory()
		{}

		public POCOProductSubcategory(int productSubcategoryID,
		                              int productCategoryID,
		                              string name,
		                              Guid rowguid,
		                              DateTime modifiedDate)
		{
			this.ProductSubcategoryID = productSubcategoryID.ToInt();
			this.Name = name;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			ProductCategoryID = new ReferenceEntity<int>(productCategoryID,
			                                             "ProductCategory");
		}

		public int ProductSubcategoryID {get; set;}
		public ReferenceEntity<int>ProductCategoryID {get; set;}
		public string Name {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductSubcategoryIDValue {get; set;} = true;

		public bool ShouldSerializeProductSubcategoryID()
		{
			return ShouldSerializeProductSubcategoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductCategoryIDValue {get; set;} = true;

		public bool ShouldSerializeProductCategoryID()
		{
			return ShouldSerializeProductCategoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeProductSubcategoryIDValue = false;
			this.ShouldSerializeProductCategoryIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>ea826ef47b2a683fe8766fa3b1fb78c9</Hash>
</Codenesium>*/