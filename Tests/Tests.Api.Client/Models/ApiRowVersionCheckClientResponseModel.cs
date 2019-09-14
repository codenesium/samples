using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiRowVersionCheckClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			Guid rowVersion)
		{
			this.Id = id;
			this.Name = name;
			this.RowVersion = rowVersion;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid RowVersion { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1dee6acf44598944d056606c6e22b84f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/