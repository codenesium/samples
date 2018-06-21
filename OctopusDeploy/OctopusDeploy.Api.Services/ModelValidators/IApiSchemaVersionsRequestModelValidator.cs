using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>7cf67ed8ce7ba6c0b9b5bd1c2208acce</Hash>
</Codenesium>*/