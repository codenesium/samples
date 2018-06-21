using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>f469d2f86cbd3f4b0948410e8c2b8e9d</Hash>
</Codenesium>*/