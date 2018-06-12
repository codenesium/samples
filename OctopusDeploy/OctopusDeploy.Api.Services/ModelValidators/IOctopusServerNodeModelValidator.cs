using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>32ec5568bc834adce805bd046d6f7bd1</Hash>
</Codenesium>*/