using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiDatabaseLogRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>98090bef2585a796ba4c82e8c0368e93</Hash>
</Codenesium>*/