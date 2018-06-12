using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiKeyAllocationRequestModel: AbstractApiRequestModel
        {
                public ApiKeyAllocationRequestModel() : base()
                {
                }

                public void SetProperties(
                        int allocated)
                {
                        this.Allocated = allocated;
                }

                private int allocated;

                [Required]
                public int Allocated
                {
                        get
                        {
                                return this.allocated;
                        }

                        set
                        {
                                this.allocated = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>1991cd0a30f2131af18a0619aa0f9687</Hash>
</Codenesium>*/