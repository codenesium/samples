using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiMachineClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string description,
			string jwtKey,
			string lastIpAddress,
			Guid machineGuid,
			string name)
		{
			this.Id = id;
			this.Description = description;
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.MachineGuid = machineGuid;
			this.Name = name;
		}

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string JwtKey { get; private set; }

		[JsonProperty]
		public string LastIpAddress { get; private set; }

		[JsonProperty]
		public Guid MachineGuid { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e65cf3234275522cfa8bd02ac589ea4f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/