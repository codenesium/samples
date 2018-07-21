using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public class ApiSchemaBPersonRequestModelValidator : AbstractApiSchemaBPersonRequestModelValidator, IApiSchemaBPersonRequestModelValidator
        {
                public ApiSchemaBPersonRequestModelValidator(ISchemaBPersonRepository schemaBPersonRepository)
                        : base(schemaBPersonRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSchemaBPersonRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaBPersonRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>32fb6cedc1e40586cf0b125a3f5f493c</Hash>
</Codenesium>*/