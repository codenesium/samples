using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiIllustrationResponseModel : AbstractApiResponseModel
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
    <Hash>b67a771aa66df52ddcfff58a2247c297</Hash>
</Codenesium>*/