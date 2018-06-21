using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiJobCandidateRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiJobCandidateRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiJobCandidateRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>efda4f894ba25e8755e93ea25228da93</Hash>
</Codenesium>*/