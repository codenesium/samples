using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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
    <Hash>3ed0e5a30ba773f04057d7cc9be29bf9</Hash>
</Codenesium>*/