using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>35aa097565ea1212f5b9e6472c1cc3e5</Hash>
</Codenesium>*/