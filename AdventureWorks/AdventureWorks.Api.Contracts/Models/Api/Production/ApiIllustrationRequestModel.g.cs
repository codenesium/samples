using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiIllustrationRequestModel : AbstractApiRequestModel
        {
                public ApiIllustrationRequestModel()
                        : base()
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
    <Hash>3a545e3b2754cf622134337896e32fff</Hash>
</Codenesium>*/