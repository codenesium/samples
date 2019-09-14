using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiVehCapabilityClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name)
		{
			this.Id = id;
			this.Name = name;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>705a22b23aa7303b46a2ed873a266458</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/