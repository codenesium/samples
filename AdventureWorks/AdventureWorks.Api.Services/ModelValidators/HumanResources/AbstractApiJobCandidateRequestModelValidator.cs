using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiJobCandidateRequestModelValidator: AbstractValidator<ApiJobCandidateRequestModel>
        {
                private int existingRecordId;

                IJobCandidateRepository jobCandidateRepository;

                public AbstractApiJobCandidateRequestModelValidator(IJobCandidateRepository jobCandidateRepository)
                {
                        this.jobCandidateRepository = jobCandidateRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiJobCandidateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void BusinessEntityIDRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void ResumeRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>65463bd26d93bd79c167d3f176cd5a77</Hash>
</Codenesium>*/