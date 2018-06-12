using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>fc86dc4c019ec79bf685145f7759aa3b</Hash>
</Codenesium>*/