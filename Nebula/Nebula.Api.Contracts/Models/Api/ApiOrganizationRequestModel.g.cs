using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiOrganizationRequestModel : AbstractApiRequestModel
        {
                public ApiOrganizationRequestModel()
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
    <Hash>7e56a3df62cb2edc55446859fab80f7b</Hash>
</Codenesium>*/