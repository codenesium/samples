using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>e2752e6be89fa426581408dc5a32a6c0</Hash>
</Codenesium>*/