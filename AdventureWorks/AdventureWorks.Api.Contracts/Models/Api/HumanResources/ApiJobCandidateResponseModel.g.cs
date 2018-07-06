using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiJobCandidateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int jobCandidateID,
                        int? businessEntityID,
                        DateTime modifiedDate,
                        string resume)
                {
                        this.JobCandidateID = jobCandidateID;
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.Resume = resume;
                }

                public int? BusinessEntityID { get; private set; }

                public int JobCandidateID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Resume { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9a410256de555f1d89f1779059c6e664</Hash>
</Codenesium>*/