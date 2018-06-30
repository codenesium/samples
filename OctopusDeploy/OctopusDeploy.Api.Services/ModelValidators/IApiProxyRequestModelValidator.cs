using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiProxyRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProxyRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiProxyRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>cdb10af4113eae051b29ef8e7146be1b</Hash>
</Codenesium>*/