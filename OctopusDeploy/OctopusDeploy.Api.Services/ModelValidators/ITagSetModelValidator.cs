using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiTagSetRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTagSetRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiTagSetRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>f3a29e290d6f68b0d4d6b55d46c673d1</Hash>
</Codenesium>*/