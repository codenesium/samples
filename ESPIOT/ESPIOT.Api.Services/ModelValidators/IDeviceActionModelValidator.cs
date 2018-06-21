using ESPIOTNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>7e057b873bbb8b4023dbda54688dc49b</Hash>
</Codenesium>*/