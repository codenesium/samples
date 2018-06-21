using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiServerTaskRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiServerTaskRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiServerTaskRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>2756b257957f37220fea304e119db4eb</Hash>
</Codenesium>*/