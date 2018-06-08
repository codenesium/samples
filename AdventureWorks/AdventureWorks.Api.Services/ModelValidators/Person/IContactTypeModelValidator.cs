using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiContactTypeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiContactTypeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>7d7ef79b9caa028361be2b7ef5873ee9</Hash>
</Codenesium>*/