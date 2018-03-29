using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOScrapReason
	{
		public POCOScrapReason()
		{}

		public POCOScrapReason(short scrapReasonID,
		                       string name,
		                       DateTime modifiedDate)
		{
			this.ScrapReasonID = scrapReasonID;
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public short ScrapReasonID {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeScrapReasonIDValue {get; set;} = true;

		public bool ShouldSerializeScrapReasonID()
		{
			return ShouldSerializeScrapReasonIDValue;
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
			this.ShouldSerializeScrapReasonIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>a7c186d5b2629f405099badf3c977f9f</Hash>
</Codenesium>*/