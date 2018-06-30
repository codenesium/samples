using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiActionTemplateVersionRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateVersionRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateVersionRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>ece2723f10c17236e8e5a4c98b6b335b</Hash>
</Codenesium>*/