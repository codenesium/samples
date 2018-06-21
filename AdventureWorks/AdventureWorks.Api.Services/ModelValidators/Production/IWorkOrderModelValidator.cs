using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiWorkOrderRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f1af490e2abc055a5fde66cf11040480</Hash>
</Codenesium>*/