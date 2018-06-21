using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepStatusRequestModel : AbstractApiRequestModel
        {
                public ApiPipelineStepStatusRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string name)
                {
                        this.Name = name;
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
        }
}

/*<Codenesium>
    <Hash>2c829536fa0dda4039f41ac60a3a63e1</Hash>
</Codenesium>*/