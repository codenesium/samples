using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiJobCandidateRequestModelValidator : AbstractValidator<ApiJobCandidateRequestModel>
        {
                private int existingRecordId;

                private IJobCandidateRepository jobCandidateRepository;

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
    <Hash>acbdf71f8208e204a227e5bd544959ce</Hash>
</Codenesium>*/