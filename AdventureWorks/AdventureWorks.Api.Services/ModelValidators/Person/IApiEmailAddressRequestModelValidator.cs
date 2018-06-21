using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>2b07fd09ff52e51e1308312af8e1e83a</Hash>
</Codenesium>*/