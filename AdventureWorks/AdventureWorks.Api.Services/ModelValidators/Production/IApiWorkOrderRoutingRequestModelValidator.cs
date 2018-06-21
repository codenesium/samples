using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>30ed212584af032816397b334866fdbd</Hash>
</Codenesium>*/