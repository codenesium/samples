using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>3712544e204332fa69f144152e5a0520</Hash>
</Codenesium>*/