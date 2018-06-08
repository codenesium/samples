using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiLocationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLocationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(short id);
        }
}

/*<Codenesium>
    <Hash>f8b0e0d27292e80d73f2775e4e7d9c82</Hash>
</Codenesium>*/