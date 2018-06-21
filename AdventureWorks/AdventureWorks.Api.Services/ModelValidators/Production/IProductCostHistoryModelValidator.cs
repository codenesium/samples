using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductCostHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductCostHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCostHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>484b5c2e16cdaf4def61e298ffa1a0b7</Hash>
</Codenesium>*/