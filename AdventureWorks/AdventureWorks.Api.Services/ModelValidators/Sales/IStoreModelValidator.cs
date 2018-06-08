using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiStoreRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiStoreRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>b9808e49d49ed319fd2ebfe593b7c06d</Hash>
</Codenesium>*/