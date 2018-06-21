using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesReasonRequestModel : AbstractApiRequestModel
        {
                public ApiSalesReasonRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        string reasonType)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ReasonType = reasonType;
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

                private string reasonType;

                [Required]
                public string ReasonType
                {
                        get
                        {
                                return this.reasonType;
                        }

                        set
                        {
                                this.reasonType = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a8f4bf87003b9cbe81dfd55483e155fb</Hash>
</Codenesium>*/