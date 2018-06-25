using Codenesium.DataConversionExtensions;
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
    <Hash>8b587307e4e3c9a15db7fb5118c755ed</Hash>
</Codenesium>*/