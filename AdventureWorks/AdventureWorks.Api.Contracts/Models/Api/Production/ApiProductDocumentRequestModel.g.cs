using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductDocumentRequestModel: AbstractApiRequestModel
        {
                public ApiProductDocumentRequestModel() : base()
                {
                }

                public void SetProperties(
                        Guid documentNode,
                        DateTime modifiedDate)
                {
                        this.DocumentNode = documentNode;
                        this.ModifiedDate = modifiedDate;
                }

                private Guid documentNode;

                [Required]
                public Guid DocumentNode
                {
                        get
                        {
                                return this.documentNode;
                        }

                        set
                        {
                                this.documentNode = value;
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
    <Hash>67f9f1828735bbbafc03aec19a7155ae</Hash>
</Codenesium>*/