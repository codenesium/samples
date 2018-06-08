using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>1fc18058e898b8163ef43a75360a1daf</Hash>
</Codenesium>*/