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

                [JsonProperty]
                public int? BusinessEntityID { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Resume { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1be3c69c92ed2c51af76e4a5928e6903</Hash>
</Codenesium>*/