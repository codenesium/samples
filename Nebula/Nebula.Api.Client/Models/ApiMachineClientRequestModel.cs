using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiMachineClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiMachineClientRequestModel()
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
		public string Description { get; private set; } = default(string);

		[JsonProperty]
		public string JwtKey { get; private set; } = default(string);

		[JsonProperty]
		public string LastIpAddress { get; private set; } = default(string);

		[JsonProperty]
		public Guid MachineGuid { get; private set; } = default(Guid);

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>606ff69b73315cbdacb12bb6c398b027</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/