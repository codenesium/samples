using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductSubcategory
	{
		public POCOProductSubcategory()
		{}

		public POCOProductSubcategory(
			DateTime modifiedDate,
			string name,
			int productCategoryID,
			int productSubcategoryID,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ProductSubcategoryID = productSubcategoryID.ToInt();
			this.Rowguid = rowguid.ToGuid();

			this.ProductCategoryID = new ReferenceEntity<int>(productCategoryID,
			                                                  nameof(ApiResponse.ProductCategories));
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public ReferenceEntity<int> ProductCategoryID { get; set; }
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
    <Hash>848cb4f9611c066c2a6c593be6ff8b3b</Hash>
</Codenesium>*/