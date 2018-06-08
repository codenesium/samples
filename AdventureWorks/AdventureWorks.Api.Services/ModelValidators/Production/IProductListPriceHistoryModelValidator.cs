using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductListPriceHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductListPriceHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductListPriceHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f3842d3b7e79473e1c56aa1de57a5b43</Hash>
</Codenesium>*/