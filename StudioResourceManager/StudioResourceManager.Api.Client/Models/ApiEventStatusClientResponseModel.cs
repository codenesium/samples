using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiEventStatusClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>6cff6e3a1bcebfd38a2d305f2fb9c966</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/