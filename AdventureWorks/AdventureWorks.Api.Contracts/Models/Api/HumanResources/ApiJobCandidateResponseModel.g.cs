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

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJobCandidateIDValue { get; set; } = true;

                public bool ShouldSerializeJobCandidateID()
                {
                        return this.ShouldSerializeJobCandidateIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeResumeValue { get; set; } = true;

                public bool ShouldSerializeResume()
                {
                        return this.ShouldSerializeResumeValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeJobCandidateIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeResumeValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>34c7ec6a038299ce8e492ec505bb7765</Hash>
</Codenesium>*/