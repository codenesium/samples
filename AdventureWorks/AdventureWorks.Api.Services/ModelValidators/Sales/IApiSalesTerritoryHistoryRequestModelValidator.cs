using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>1c20a397b96fc9467dcb151d16d9df64</Hash>
</Codenesium>*/