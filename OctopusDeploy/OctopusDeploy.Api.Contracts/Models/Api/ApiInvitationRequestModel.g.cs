using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>29c3e8a080c43ee6ea8ed5bfc7caf9ad</Hash>
</Codenesium>*/