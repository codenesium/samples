using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>dd26be7262273ba7bb0230522daaac79</Hash>
</Codenesium>*/