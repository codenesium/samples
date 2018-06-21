using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiKeyAllocationRequestModel : AbstractApiRequestModel
        {
                public ApiKeyAllocationRequestModel()
                        : base()
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
    <Hash>3c76c5ef444a2cb18c66c2677261e404</Hash>
</Codenesium>*/