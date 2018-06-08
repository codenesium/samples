using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiWorkOrderRoutingRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRoutingRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRoutingRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>0b55693eb832f6939bd386ac9063697a</Hash>
</Codenesium>*/