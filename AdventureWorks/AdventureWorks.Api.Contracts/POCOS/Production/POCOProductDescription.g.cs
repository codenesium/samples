using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductDescription: AbstractPOCO
	{
		public POCOProductDescription() : base()
		{}

		public POCOProductDescription(
			string description,
			DateTime modifiedDate,
			int productDescriptionID,
			Guid rowguid)
		{
			this.Description = description;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public string Description { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductDescriptionID { get; set; }
		public Guid Rowguid { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue { get; set; } = true;

		public bool ShouldSerializeDescription()
		{
			return this.ShouldSerializeDescriptionValue;
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
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDescriptionValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductDescriptionIDValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d8c4e1950dbf08467bff3467d2530e93</Hash>
</Codenesium>*/