using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiSchemaVersionsRequestModelValidator: AbstractApiSchemaVersionsRequestModelValidator, IApiSchemaVersionsRequestModelValidator
        {
                public ApiSchemaVersionsRequestModelValidator(ISchemaVersionsRepository schemaVersionsRepository)
                        : base(schemaVersionsRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSchemaVersionsRequestModel model)
                {
                        this.AppliedRules();
                        this.ScriptNameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaVersionsRequestModel model)
                {
                        this.AppliedRules();
                        this.ScriptNameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>2ce3c275641959068766760e3970f726</Hash>
</Codenesium>*/