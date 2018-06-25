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

                public virtual void SetProperties(
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
                                return this.diagram;
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
    <Hash>cac3f5f601b245aab5f945b601ed71c4</Hash>
</Codenesium>*/