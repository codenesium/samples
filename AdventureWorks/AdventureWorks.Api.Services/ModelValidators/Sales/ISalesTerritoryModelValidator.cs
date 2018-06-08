using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>7169c6f560fedddb48b4853ea189cfa0</Hash>
</Codenesium>*/