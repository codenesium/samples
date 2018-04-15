using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductModel
	{
		public POCOProductModel()
		{}

		public POCOProductModel(
			int productModelID,
			string name,
			string catalogDescription,
			string instructions,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.ProductModelID = productModelID.ToInt();
			this.Name = name.ToString();
			this.CatalogDescription = catalogDescription;
			this.Instructions = instructions;
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductModelID { get; set; }
		public string Name { get; set; }
		public string CatalogDescription { get; set; }
		public string Instructions { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue { get; set; } = true;

		public bool ShouldSerializeProductModelID()
		{
			return this.ShouldSerializeProductModelIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCatalogDescriptionValue { get; set; } = true;

		public bool ShouldSerializeCatalogDescription()
		{
			return this.ShouldSerializeCatalogDescriptionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeInstructionsValue { get; set; } = true;

		public bool ShouldSerializeInstructions()
		{
			return this.ShouldSerializeInstructionsValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
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
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeCatalogDescriptionValue = false;
			this.ShouldSerializeInstructionsValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>14795d99f4d5c2332ac5f16c6e199a5f</Hash>
</Codenesium>*/