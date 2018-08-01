using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiInvitationRequestModel : AbstractApiRequestModel
	{
		public ApiInvitationRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string invitationCode,
			string jSON)
		{
			this.InvitationCode = invitationCode;
			this.JSON = jSON;
		}

		[JsonProperty]
		public string InvitationCode { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d4ad4d8ef046732adcfb5af3dccacb4a</Hash>
</Codenesium>*/