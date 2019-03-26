using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiIllustrationClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int illustrationID,
			string diagram,
			DateTime modifiedDate)
		{
			this.IllustrationID = illustrationID;
			this.Diagram = diagram;
			this.ModifiedDate = modifiedDate;
		}

		[JsonProperty]
		public string Diagram { get; private set; }

		[JsonProperty]
		public int IllustrationID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5d72ee208bafb923954be0fc5cad805b</Hash>
</Codenesium>*/