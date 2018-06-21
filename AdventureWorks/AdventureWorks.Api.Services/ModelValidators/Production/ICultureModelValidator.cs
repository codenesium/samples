using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiCultureRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCultureRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiCultureRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>9a6b3a59a0b3bdf4ca703cd0fca2b1d3</Hash>
</Codenesium>*/