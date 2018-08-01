using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiScrapReasonResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			short scrapReasonID,
			DateTime modifiedDate,
			string name)
		{
			this.ScrapReasonID = scrapReasonID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public short ScrapReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f215b652bd88d20f016a0984c31bad38</Hash>
</Codenesium>*/