using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>a74a5b91cafcf523099b71f04519b08b</Hash>
</Codenesium>*/