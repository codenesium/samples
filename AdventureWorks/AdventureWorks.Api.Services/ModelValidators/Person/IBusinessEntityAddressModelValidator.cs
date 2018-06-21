using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>3c0db3e57dab14f1840153c768484983</Hash>
</Codenesium>*/