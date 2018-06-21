using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
        public partial class ApiFileTypeRequestModel : AbstractApiRequestModel
        {
                public ApiFileTypeRequestModel()
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
    <Hash>d5af4eb3e5fc20448e87c17adfa2a4e1</Hash>
</Codenesium>*/