using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>d3a37d7db3cc1db2874456e40c5f2056</Hash>
</Codenesium>*/