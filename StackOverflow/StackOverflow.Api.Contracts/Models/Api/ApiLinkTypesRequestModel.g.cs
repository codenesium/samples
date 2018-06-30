using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiLinkTypesRequestModel : AbstractApiRequestModel
        {
                public ApiLinkTypesRequestModel()
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
    <Hash>3e6a6d5fb9c53b40e8035c2e9a916a32</Hash>
</Codenesium>*/