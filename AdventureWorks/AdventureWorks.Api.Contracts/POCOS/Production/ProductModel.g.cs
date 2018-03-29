using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductModel
	{
		public POCOProductModel()
		{}

		public POCOProductModel(int productModelID,
		                        string name,
		                        string catalogDescription,
		                        string instructions,
		                        Guid rowguid,
		                        DateTime modifiedDate)
		{
			this.ProductModelID = productModelID.ToInt();
			this.Name = name;
			this.CatalogDescription = catalogDescription;
			this.Instructions = instructions;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductModelID {get; set;}
		public string Name {get; set;}
		public string CatalogDescription {get; set;}
		public string Instructions {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue {get; set;} = true;

		public bool ShouldSerializeProductModelID()
		{
			return ShouldSerializeProductModelIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCatalogDescriptionValue {get; set;} = true;

		public bool ShouldSerializeCatalogDescription()
		{
			return ShouldSerializeCatalogDescriptionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeInstructionsValue {get; set;} = true;

		public bool ShouldSerializeInstructions()
		{
			return ShouldSerializeInstructionsValue;
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
    <Hash>b3deccce12f8a04bb70f17983c306581</Hash>
</Codenesium>*/