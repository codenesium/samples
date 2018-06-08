using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiBusinessEntityAddressRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityAddressRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityAddressRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>065bf5b8641059f15eb612fba3ee4860</Hash>
</Codenesium>*/