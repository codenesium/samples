using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSalesReasonRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>da67a3b5c21a7da1e21298d4e7518bd8</Hash>
</Codenesium>*/