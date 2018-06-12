using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiSchemaVersionsRequestModelValidator: AbstractApiSchemaVersionsRequestModelValidator, IApiSchemaVersionsRequestModelValidator
        {
                public ApiSchemaVersionsRequestModelValidator()
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
    <Hash>b6ef1e1e40d9b1f5505371626147cc98</Hash>
</Codenesium>*/