using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiMachineResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public string Description { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JwtKey { get; private set; }

		[Required]
		[JsonProperty]
		public string LastIpAddress { get; private set; }

		[Required]
		[JsonProperty]
		public Guid MachineGuid { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0fb0736f44a75345006a00be03bd152f</Hash>
</Codenesium>*/