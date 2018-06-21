using Codenesium.DataConversionExtensions;
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

                public void SetProperties(
                        string invitationCode,
                        string jSON)
                {
                        this.InvitationCode = invitationCode;
                        this.JSON = jSON;
                }

                private string invitationCode;

                [Required]
                public string InvitationCode
                {
                        get
                        {
                                return this.invitationCode;
                        }

                        set
                        {
                                this.invitationCode = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>96c8c4891162701aff27ab55e629b18b</Hash>
</Codenesium>*/