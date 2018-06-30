using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>9d97945f341904c625923cc4ae11787a</Hash>
</Codenesium>*/