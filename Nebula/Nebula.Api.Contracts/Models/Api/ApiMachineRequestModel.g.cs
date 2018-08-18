using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiMachineRequestModel : AbstractApiRequestModel
	{
		public ApiMachineRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string description,
			string jwtKey,
			string lastIpAddress,
			Guid machineGuid,
			string name)
		{
			this.Description = description;
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.MachineGuid = machineGuid;
			this.Name = name;
		}

		[JsonProperty]
		public string Description { get; private set; }

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
    <Hash>d241a59ac4c68447c15e41bc855364fc</Hash>
</Codenesium>*/