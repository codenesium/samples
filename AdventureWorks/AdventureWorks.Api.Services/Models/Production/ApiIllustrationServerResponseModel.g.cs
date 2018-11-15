using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiIllustrationServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public string Diagram { get; private set; }

		[JsonProperty]
		public int IllustrationID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>55689ba128707d3046e73794bde090a8</Hash>
</Codenesium>*/