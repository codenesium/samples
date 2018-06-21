using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSalesPersonQuotaHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonQuotaHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonQuotaHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>3970597eea6efb8bcd8b4c2c21099f2d</Hash>
</Codenesium>*/