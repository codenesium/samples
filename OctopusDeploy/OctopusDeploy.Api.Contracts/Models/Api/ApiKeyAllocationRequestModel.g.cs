using Codenesium.DataConversionExtensions;
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
    <Hash>7541378f2d6602b30e19a6192e6eaeb6</Hash>
</Codenesium>*/