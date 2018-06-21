using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiCommunityActionTemplateRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCommunityActionTemplateRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiCommunityActionTemplateRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>a4a98305320faedb18cff2d2cd542102</Hash>
</Codenesium>*/