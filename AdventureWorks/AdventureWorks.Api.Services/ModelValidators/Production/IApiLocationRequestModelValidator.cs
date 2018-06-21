using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiLocationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLocationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(short id);
        }
}

/*<Codenesium>
    <Hash>bede6bd9a9c57f3d2f24c2d9904504e8</Hash>
</Codenesium>*/