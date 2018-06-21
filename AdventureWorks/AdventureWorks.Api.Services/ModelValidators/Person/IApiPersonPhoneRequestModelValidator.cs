using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiPersonPhoneRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPersonPhoneRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonPhoneRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c98c3050a6a65e494673a497f0f27cfa</Hash>
</Codenesium>*/