using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCulture
	{
		public POCOCulture()
		{}

		public POCOCulture(string cultureID,
		                   string name,
		                   DateTime modifiedDate)
		{
			this.CultureID = cultureID;
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string CultureID {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeCultureIDValue {get; set;} = true;

		public bool ShouldSerializeCultureID()
		{
			return ShouldSerializeCultureIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCultureIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>48098c04b84d45e186a5e3319e479e3b</Hash>
</Codenesium>*/