using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiInvitationResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string invitationCode,
			string jSON)
		{
			this.Id = id;
			this.InvitationCode = invitationCode;
			this.JSON = jSON;
		}

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string InvitationCode { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9a9c23982c99124165a6b7bbf85a20f4</Hash>
</Codenesium>*/