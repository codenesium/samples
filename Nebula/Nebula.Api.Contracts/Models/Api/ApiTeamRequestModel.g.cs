using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiTeamRequestModel: AbstractApiRequestModel
        {
                public ApiTeamRequestModel() : base()
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
    <Hash>50aacd80498f09b28aa02ecdbf950650</Hash>
</Codenesium>*/