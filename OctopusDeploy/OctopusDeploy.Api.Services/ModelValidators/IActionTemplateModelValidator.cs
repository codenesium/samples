using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>2003fa76ddf96d011d6887d3ae4a52f6</Hash>
</Codenesium>*/