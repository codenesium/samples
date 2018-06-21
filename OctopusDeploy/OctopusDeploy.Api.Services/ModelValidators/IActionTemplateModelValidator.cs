using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiActionTemplateRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>d84e748afc7a69aeb0a54613f71bf17d</Hash>
</Codenesium>*/