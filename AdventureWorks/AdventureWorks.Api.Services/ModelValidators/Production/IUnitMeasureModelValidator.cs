using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiUnitMeasureRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>c502c778cbb47a786a09215d4d6e208d</Hash>
</Codenesium>*/