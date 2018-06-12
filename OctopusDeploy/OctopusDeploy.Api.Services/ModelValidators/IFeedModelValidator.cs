using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiFeedRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiFeedRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiFeedRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>38cbeb7e4d41c650c8ff5708a1e43106</Hash>
</Codenesium>*/