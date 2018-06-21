using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiEmployeeDepartmentHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiEmployeeDepartmentHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeDepartmentHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>eb7b2b4a280545bd570602f02a51f50d</Hash>
</Codenesium>*/