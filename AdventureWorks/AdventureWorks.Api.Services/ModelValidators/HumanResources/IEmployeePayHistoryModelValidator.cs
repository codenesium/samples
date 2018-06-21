using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>9ff4df35ef7e50b88c6b55ad18535cb4</Hash>
</Codenesium>*/