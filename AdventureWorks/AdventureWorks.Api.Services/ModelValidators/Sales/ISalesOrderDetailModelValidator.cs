using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>bdb7fb091819f7cbb2d12e7729f4ad9a</Hash>
</Codenesium>*/