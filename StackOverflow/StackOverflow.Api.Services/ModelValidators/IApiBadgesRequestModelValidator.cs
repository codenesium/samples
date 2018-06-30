using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiBadgesRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBadgesRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgesRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>e8033231f90bc67748ecb3071a3cc567</Hash>
</Codenesium>*/