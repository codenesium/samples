using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiEmployeePayHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiEmployeePayHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeePayHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>7c3f88013f12942cc5b080b05a5665bf</Hash>
</Codenesium>*/