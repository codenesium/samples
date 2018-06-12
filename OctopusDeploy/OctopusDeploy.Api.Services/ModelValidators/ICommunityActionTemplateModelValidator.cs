using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>e91615db8af574cab37e36f4dcf8a693</Hash>
</Codenesium>*/