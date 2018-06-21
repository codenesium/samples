using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiAccountRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiAccountRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiAccountRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>da840141b8bddb443d11eeb887770650</Hash>
</Codenesium>*/