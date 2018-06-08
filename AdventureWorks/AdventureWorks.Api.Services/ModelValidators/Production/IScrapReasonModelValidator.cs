using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiScrapReasonRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(short id);
        }
}

/*<Codenesium>
    <Hash>c69ea1369e77977094a21bf067e6ba4f</Hash>
</Codenesium>*/