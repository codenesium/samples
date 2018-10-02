using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiSysdiagramResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int diagramId,
			byte[] definition,
			string name,
			int principalId,
			int? version)
		{
			this.DiagramId = diagramId;
			this.Definition = definition;
			this.Name = name;
			this.PrincipalId = principalId;
			this.Version = version;
		}

		[Required]
		[JsonProperty]
		public byte[] Definition { get; private set; }

		[JsonProperty]
		public int DiagramId { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int PrincipalId { get; private set; }

		[Required]
		[JsonProperty]
		public int? Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>16848ceac4b6279fadfb45bb7cc6467d</Hash>
</Codenesium>*/