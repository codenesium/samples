using ESPIOTNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
        public interface IApiDeviceRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDeviceRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f8f20f0555dc54a6a42a03fdf8985a04</Hash>
</Codenesium>*/