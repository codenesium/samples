using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiEmployeeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiEmployeeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>72a8c1403eee11b1a3efa872cf1f84a7</Hash>
</Codenesium>*/