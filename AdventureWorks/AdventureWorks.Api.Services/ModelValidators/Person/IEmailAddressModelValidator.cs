using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiEmailAddressRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiEmailAddressRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmailAddressRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a4fdfc0d2760787d49a24f42c652088b</Hash>
</Codenesium>*/