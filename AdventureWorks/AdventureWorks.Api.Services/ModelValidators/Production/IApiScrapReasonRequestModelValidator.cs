using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>982a45040d6096d71af21bc183efe017</Hash>
</Codenesium>*/