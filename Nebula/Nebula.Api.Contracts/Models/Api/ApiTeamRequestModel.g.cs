using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiTeamRequestModel : AbstractApiRequestModel
        {
                public ApiTeamRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string name,
                        int organizationId)
                {
                        this.Name = name;
                        this.OrganizationId = organizationId;
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private int organizationId;

                [Required]
                public int OrganizationId
                {
                        get
                        {
                                return this.organizationId;
                        }

                        set
                        {
                                this.organizationId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>fe05ea36a52b546d5012d5dcb0119eb6</Hash>
</Codenesium>*/