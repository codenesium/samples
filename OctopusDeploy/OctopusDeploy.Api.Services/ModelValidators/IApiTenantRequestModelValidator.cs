using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiTenantRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTenantRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>2ae18a839271acabb6c50b2def7d1234</Hash>
</Codenesium>*/