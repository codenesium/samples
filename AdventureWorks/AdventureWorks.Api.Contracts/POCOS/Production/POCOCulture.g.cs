using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCulture: AbstractPOCO
	{
		public POCOCulture() : base()
		{}

		public POCOCulture(
			string cultureID,
			DateTime modifiedDate,
			string name)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public string CultureID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }

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
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCultureIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>6772af4299a6152d33a50b3269a8b45a</Hash>
</Codenesium>*/