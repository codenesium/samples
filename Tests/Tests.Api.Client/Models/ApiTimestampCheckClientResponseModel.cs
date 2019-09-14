using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiTimestampCheckClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			byte[] timestamp)
		{
			this.Id = id;
			this.Name = name;
			this.Timestamp = timestamp;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public byte[] Timestamp { get; private set; }
	}
}

/*<Codenesium>
    <Hash>accbebaf5ad3ab19acf90b0a30a77d0c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/