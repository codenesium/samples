using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiCultureClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			string cultureID,
			DateTime modifiedDate,
			string name)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public string CultureID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>847e983e082200049a0ea1c2326f3eff</Hash>
</Codenesium>*/