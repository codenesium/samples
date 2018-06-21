using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>243feeb1c123cd582784489ec5ab3d9e</Hash>
</Codenesium>*/