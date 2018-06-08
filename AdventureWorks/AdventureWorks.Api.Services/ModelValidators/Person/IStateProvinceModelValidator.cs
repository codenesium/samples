using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>03b0e4c9dc2243493ceef4bd5d8c0da3</Hash>
</Codenesium>*/