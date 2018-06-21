using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiBusinessEntityRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>2ce6b715ac5bf7e7f3d3b7173f9df823</Hash>
</Codenesium>*/