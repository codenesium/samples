using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCultureRequestModel : AbstractApiRequestModel
        {
                public ApiCultureRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
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
    <Hash>74b35bce5a56f7bbb16a757ef89ecb4c</Hash>
</Codenesium>*/