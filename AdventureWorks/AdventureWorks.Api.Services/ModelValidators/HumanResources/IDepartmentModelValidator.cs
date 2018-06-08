using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiDepartmentRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDepartmentRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(short id, ApiDepartmentRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(short id);
        }
}

/*<Codenesium>
    <Hash>c28380c66c483e2f2d5535b45e18ce20</Hash>
</Codenesium>*/