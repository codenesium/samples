using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiScrapReasonResponseModel: AbstractApiResponseModel
	{
		public ApiScrapReasonResponseModel() : base()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			string name,
			short scrapReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
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
    <Hash>499f8baddbd51d4e08bc9da7a6407336</Hash>
</Codenesium>*/