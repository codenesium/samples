using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiMachineServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>84ee0f798e8a2ff5bcd9a891f804c609</Hash>
</Codenesium>*/