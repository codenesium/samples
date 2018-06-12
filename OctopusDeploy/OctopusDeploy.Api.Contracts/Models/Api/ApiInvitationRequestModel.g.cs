using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiInvitationRequestModel: AbstractApiRequestModel
        {
                public ApiInvitationRequestModel() : base()
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
    <Hash>ff08e0e9b6a09c0011303e0eec5f8059</Hash>
</Codenesium>*/