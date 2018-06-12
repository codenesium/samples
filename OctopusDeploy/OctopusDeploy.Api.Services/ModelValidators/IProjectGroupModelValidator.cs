using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiProjectGroupRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProjectGroupRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectGroupRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>7a5cac8303a9793dba996c06e31c00ca</Hash>
</Codenesium>*/