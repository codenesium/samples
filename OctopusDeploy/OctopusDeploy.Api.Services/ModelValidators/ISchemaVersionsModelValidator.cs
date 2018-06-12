using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiSchemaVersionsRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSchemaVersionsRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaVersionsRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>45131c9b0011f795f8a3292a9568305e</Hash>
</Codenesium>*/