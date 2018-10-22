using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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

		[Required]
		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string JwtKey { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string LastIpAddress { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid MachineGuid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>b1e5a483b3efffdcd45e471ca75fd2e6</Hash>
</Codenesium>*/