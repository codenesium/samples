using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiJobCandidateRequestModel : AbstractApiRequestModel
        {
                public ApiJobCandidateRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        Nullable<int> businessEntityID,
                        DateTime modifiedDate,
                        string resume)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.Resume = resume;
                }

                private Nullable<int> businessEntityID;

                public Nullable<int> BusinessEntityID
                {
                        get
                        {
                                return this.businessEntityID.IsEmptyOrZeroOrNull() ? null : this.businessEntityID;
                        }

                        set
                        {
                                this.businessEntityID = value;
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

                private string resume;

                public string Resume
                {
                        get
                        {
                                return this.resume.IsEmptyOrZeroOrNull() ? null : this.resume;
                        }

                        set
                        {
                                this.resume = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>025e99bcdc684b1ead4764a8ef11d24b</Hash>
</Codenesium>*/