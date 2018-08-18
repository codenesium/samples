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
    <Hash>1045f48d18052ea88c03a89b974bcc6e</Hash>
</Codenesium>*/