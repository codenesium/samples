using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiOctopusServerNodeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiOctopusServerNodeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiOctopusServerNodeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>0113cbbcadfd89a4182edfff2fb8ef44</Hash>
</Codenesium>*/