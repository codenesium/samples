using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiJobCandidateRequestModelValidator : AbstractApiJobCandidateRequestModelValidator, IApiJobCandidateRequestModelValidator
        {
                public ApiJobCandidateRequestModelValidator(IJobCandidateRepository jobCandidateRepository)
                        : base(jobCandidateRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiJobCandidateRequestModel model)
                {
                        this.BusinessEntityIDRules();
                        this.ModifiedDateRules();
                        this.ResumeRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiJobCandidateRequestModel model)
                {
                        this.BusinessEntityIDRules();
                        this.ModifiedDateRules();
                        this.ResumeRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>d0f2f16cb0d12674c482c2027aabb8fc</Hash>
</Codenesium>*/