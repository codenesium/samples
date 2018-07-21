using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public class ApiSelfReferenceRequestModelValidator : AbstractApiSelfReferenceRequestModelValidator, IApiSelfReferenceRequestModelValidator
        {
                public ApiSelfReferenceRequestModelValidator(ISelfReferenceRepository selfReferenceRepository)
                        : base(selfReferenceRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSelfReferenceRequestModel model)
                {
                        this.SelfReferenceIdRules();
                        this.SelfReferenceId2Rules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSelfReferenceRequestModel model)
                {
                        this.SelfReferenceIdRules();
                        this.SelfReferenceId2Rules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>930f9e9a81b63e94630dd226e00a14dd</Hash>
</Codenesium>*/