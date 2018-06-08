using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.Services
{
        public interface IApiDeviceActionRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>68fc25989b8b810ad1c3c6ddaf72fc26</Hash>
</Codenesium>*/