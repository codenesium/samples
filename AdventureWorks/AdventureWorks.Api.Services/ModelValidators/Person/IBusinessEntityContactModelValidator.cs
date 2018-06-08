using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>ed3c960a15317b22fe0cd4b98634b4e7</Hash>
</Codenesium>*/