using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSalesOrderHeaderRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>4a154ad664f26b1d9919157afd9709c5</Hash>
</Codenesium>*/