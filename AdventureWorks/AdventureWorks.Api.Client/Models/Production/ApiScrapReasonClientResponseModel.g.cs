using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiScrapReasonClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>6e10d337311766304dae72cc63219b92</Hash>
</Codenesium>*/