using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiSysdiagramRequestModel : AbstractApiRequestModel
	{
		public ApiSysdiagramRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			byte[] definition,
			string name,
			int principalId,
			int? version)
		{
			this.Definition = definition;
			this.Name = name;
			this.PrincipalId = principalId;
			this.Version = version;
		}

		[JsonProperty]
		public byte[] Definition { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int PrincipalId { get; private set; }

		[JsonProperty]
		public int? Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6c4f3485d5dcb4846d64ec5043e05116</Hash>
</Codenesium>*/