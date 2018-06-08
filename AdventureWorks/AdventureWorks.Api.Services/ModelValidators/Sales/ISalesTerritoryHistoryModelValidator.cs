using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSalesTerritoryHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>6bf342c0893bc9b1c27cfa986d1ec34f</Hash>
</Codenesium>*/