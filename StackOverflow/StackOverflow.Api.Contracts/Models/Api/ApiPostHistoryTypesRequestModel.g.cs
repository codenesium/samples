using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostHistoryTypesRequestModel : AbstractApiRequestModel
        {
                public ApiPostHistoryTypesRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
    <Hash>feb6544f8c8851cf7083bfb7d1b73150</Hash>
</Codenesium>*/