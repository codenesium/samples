using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiIllustrationRequestModel: AbstractApiRequestModel
        {
                public ApiIllustrationRequestModel() : base()
                {
                }

                public void SetProperties(
                        string diagram,
                        DateTime modifiedDate)
                {
                        this.Diagram = diagram;
                        this.ModifiedDate = modifiedDate;
                }

                private string diagram;

                public string Diagram
                {
                        get
                        {
                                return this.diagram.IsEmptyOrZeroOrNull() ? null : this.diagram;
                        }

                        set
                        {
                                this.diagram = value;
                        }
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
        }
}

/*<Codenesium>
    <Hash>c547d8f6adf785e18eaea4bef83aab23</Hash>
</Codenesium>*/