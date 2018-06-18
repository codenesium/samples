using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiJobCandidateRequestModelValidator: AbstractApiJobCandidateRequestModelValidator, IApiJobCandidateRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>72c7c2271e5339181d459aa7ce98de21</Hash>
</Codenesium>*/