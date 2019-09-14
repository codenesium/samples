using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiIncludedColumnTestClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			string name2)
		{
			this.Id = id;
			this.Name = name;
			this.Name2 = name2;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string Name2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ac00e417e90f1b3020c18ff25b3f3457</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/