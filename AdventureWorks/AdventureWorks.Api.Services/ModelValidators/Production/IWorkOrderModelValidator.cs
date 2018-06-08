using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>becde819f8dcbe0bda0f53ed4ec0811f</Hash>
</Codenesium>*/