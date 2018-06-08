using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductCostHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductCostHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCostHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>9ba2fd1e6730cd6633411971996687f9</Hash>
</Codenesium>*/