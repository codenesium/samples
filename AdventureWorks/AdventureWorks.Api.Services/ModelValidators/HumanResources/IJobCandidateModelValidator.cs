using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>69be05facfa2faf3049e663dd035477f</Hash>
</Codenesium>*/