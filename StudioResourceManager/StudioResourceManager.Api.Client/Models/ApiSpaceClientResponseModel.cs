using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiSpaceClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string description,
			string name)
		{
			this.Id = id;
			this.Description = description;
			this.Name = name;
		}

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8387f7d61ba40793058cadfa6efa5195</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/