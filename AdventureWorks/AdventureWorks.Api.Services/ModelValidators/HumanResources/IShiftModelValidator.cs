using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiShiftRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiShiftRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>7669ba0367a98a82c2881701ab1e2a34</Hash>
</Codenesium>*/