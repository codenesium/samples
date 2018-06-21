using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
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
    <Hash>4ca119d7ca06a187511e802d6421109c</Hash>
</Codenesium>*/