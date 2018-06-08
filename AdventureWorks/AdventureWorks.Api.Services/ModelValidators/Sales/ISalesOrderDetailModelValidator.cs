using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSalesOrderDetailRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderDetailRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderDetailRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>17f3ad4b69c92899cbc38315f1c85af1</Hash>
</Codenesium>*/