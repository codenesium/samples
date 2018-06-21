using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductModelRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductModelRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>746c019ff1640dfca1a29c03226a209a</Hash>
</Codenesium>*/