using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public class ApiSchemaAPersonRequestModelValidator : AbstractApiSchemaAPersonRequestModelValidator, IApiSchemaAPersonRequestModelValidator
        {
                public ApiSchemaAPersonRequestModelValidator(ISchemaAPersonRepository schemaAPersonRepository)
                        : base(schemaAPersonRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSchemaAPersonRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaAPersonRequestModel model)
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
    <Hash>b1917348fec850f221de2b3be94c1b98</Hash>
</Codenesium>*/