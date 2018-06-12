using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>f7bed1f35f02159bfe63d8ef09d0d7c1</Hash>
</Codenesium>*/