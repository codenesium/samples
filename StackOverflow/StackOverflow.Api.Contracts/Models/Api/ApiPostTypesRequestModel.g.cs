using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostTypesRequestModel : AbstractApiRequestModel
        {
                public ApiPostTypesRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string type)
                {
                        this.Type = type;
                }

                private string type;

                [Required]
                public string Type
                {
                        get
                        {
                                return this.type;
                        }

                        set
                        {
                                this.type = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>4d8c1471e0930c4ffc5a4709cd387328</Hash>
</Codenesium>*/