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

                public virtual void SetProperties(
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
    <Hash>9f11f38312ebdeb9ea2feb4023c1dada</Hash>
</Codenesium>*/