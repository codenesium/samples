using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>9798a6c517c606ca767b2d6236bbeeaf</Hash>
</Codenesium>*/