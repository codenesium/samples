using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>6c052157c1891ebcb78491338059a58b</Hash>
</Codenesium>*/