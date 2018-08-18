using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOInvitation : AbstractBusinessObject
	{
		public AbstractBOInvitation()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  string invitationCode,
		                                  string jSON)
		{
			this.Id = id;
			this.InvitationCode = invitationCode;
			this.JSON = jSON;
		}

		public string Id { get; private set; }

		public string InvitationCode { get; private set; }

		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dfde0d3da3162ac8ab159781ae79808a</Hash>
</Codenesium>*/