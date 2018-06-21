using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiStateProvinceRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a7f91853f053f30c939c99bebc32bccc</Hash>
</Codenesium>*/