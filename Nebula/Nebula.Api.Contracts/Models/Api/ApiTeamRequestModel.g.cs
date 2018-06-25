using Codenesium.DataConversionExtensions;
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

                public virtual void SetProperties(
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
    <Hash>2eb92d8ffb591a68710bde816cef9887</Hash>
</Codenesium>*/