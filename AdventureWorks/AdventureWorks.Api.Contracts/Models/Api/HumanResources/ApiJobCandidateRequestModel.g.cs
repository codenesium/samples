using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
                        int? businessEntityID,
                        DateTime modifiedDate,
                        string resume)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.Resume = resume;
                }

                private int? businessEntityID;

                public int? BusinessEntityID
                {
                        get
                        {
                                return this.businessEntityID;
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
                                return this.resume;
                        }

                        set
                        {
                                this.resume = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>9911ad7472efa129daebeb24fbc401f7</Hash>
</Codenesium>*/