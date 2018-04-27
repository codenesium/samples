using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOScrapReason
	{
		public POCOScrapReason()
		{}

		public POCOScrapReason(
			DateTime modifiedDate,
			string name,
			short scrapReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ScrapReasonID = scrapReasonID;
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public short ScrapReasonID { get; set; }

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
		public bool ShouldSerializeScrapReasonIDValue { get; set; } = true;

		public bool ShouldSerializeScrapReasonID()
		{
			return this.ShouldSerializeScrapReasonIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeScrapReasonIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>75c3d77fedf218ae0d2f174863904e47</Hash>
</Codenesium>*/