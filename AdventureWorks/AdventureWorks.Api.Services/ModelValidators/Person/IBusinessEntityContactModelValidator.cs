using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiBusinessEntityContactRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a7201e5d6e7e04392f5e914e25d2239e</Hash>
</Codenesium>*/