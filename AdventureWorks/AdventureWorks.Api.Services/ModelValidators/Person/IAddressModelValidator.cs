using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiAddressRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiAddressRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>351dfecb2d7adc941a53e14b42b42314</Hash>
</Codenesium>*/