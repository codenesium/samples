using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductDescription
	{
		public POCOProductDescription()
		{}

		public POCOProductDescription(int productDescriptionID,
		                              string description,
		                              Guid rowguid,
		                              DateTime modifiedDate)
		{
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.Description = description;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductDescriptionID {get; set;}
		public string Description {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductDescriptionIDValue {get; set;} = true;

		public bool ShouldSerializeProductDescriptionID()
		{
			return ShouldSerializeProductDescriptionIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue {get; set;} = true;

		public bool ShouldSerializeDescription()
		{
			return ShouldSerializeDescriptionValue;
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
			this.ShouldSerializeProductDescriptionIDValue = false;
			this.ShouldSerializeDescriptionValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>7c91223b8ba499788095bca96365f7f6</Hash>
</Codenesium>*/