using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductModel: AbstractPOCO
	{
		public POCOProductModel() : base()
		{}

		public POCOProductModel(
			string catalogDescription,
			string instructions,
			DateTime modifiedDate,
			string name,
			int productModelID,
			Guid rowguid)
		{
			this.CatalogDescription = catalogDescription;
			this.Instructions = instructions;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ProductModelID = productModelID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public string CatalogDescription { get; set; }
		public string Instructions { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public int ProductModelID { get; set; }
		public Guid Rowguid { get; set; }

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
		public bool ShouldSerializeProductModelIDValue { get; set; } = true;

		public bool ShouldSerializeProductModelID()
		{
			return this.ShouldSerializeProductModelIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCatalogDescriptionValue = false;
			this.ShouldSerializeInstructionsValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeProductModelIDValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d226f0153be78dfdead2f67bfcf6a86e</Hash>
</Codenesium>*/