using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;

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
    <Hash>7b049604edb74a2cbd1e3a9d8461274e</Hash>
</Codenesium>*/