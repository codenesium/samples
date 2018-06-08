using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiJobCandidateResponseModel: AbstractApiResponseModel
        {
                public ApiJobCandidateResponseModel() : base()
                {
                }

                public void SetProperties(
                        Nullable<int> businessEntityID,
                        int jobCandidateID,
                        DateTime modifiedDate,
                        string resume)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.JobCandidateID = jobCandidateID;
                        this.ModifiedDate = modifiedDate;
                        this.Resume = resume;
                }

                public Nullable<int> BusinessEntityID { get; private set; }

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

                public void DisableAllFields()
                {
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeJobCandidateIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeResumeValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>9b63d0fe1b6a09bb2f061411a992d810</Hash>
</Codenesium>*/