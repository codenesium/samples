using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiTagSetRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTagSetRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiTagSetRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>326a8afbe2ee6cb2493b32489ad7e426</Hash>
</Codenesium>*/