using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiPersonRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPersonRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>db908ee0889438b2cc51458d4721a8ef</Hash>
</Codenesium>*/