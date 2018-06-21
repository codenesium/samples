using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSalesTerritoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>21bdcd66d7e32b9cd6b4fff6b46ff465</Hash>
</Codenesium>*/