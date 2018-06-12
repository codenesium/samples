using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOInvitation: AbstractBusinessObject
        {
                public BOInvitation() : base()
                {
                }

                public void SetProperties(string id,
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
    <Hash>1d5edb26f2e3f5016aa1fd4ee2f4314c</Hash>
</Codenesium>*/