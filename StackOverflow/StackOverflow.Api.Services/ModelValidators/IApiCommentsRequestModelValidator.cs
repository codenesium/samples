using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiCommentsRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCommentsRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentsRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>8b487b12a883be29ffce76a14c5ad12f</Hash>
</Codenesium>*/