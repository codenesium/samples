using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public class ApiVotesRequestModelValidator : AbstractApiVotesRequestModelValidator, IApiVotesRequestModelValidator
        {
                public ApiVotesRequestModelValidator(IVotesRepository votesRepository)
                        : base(votesRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiVotesRequestModel model)
                {
                        this.BountyAmountRules();
                        this.CreationDateRules();
                        this.PostIdRules();
                        this.UserIdRules();
                        this.VoteTypeIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVotesRequestModel model)
                {
                        this.BountyAmountRules();
                        this.CreationDateRules();
                        this.PostIdRules();
                        this.UserIdRules();
                        this.VoteTypeIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>b301c6599a4739727d42d81570cf990d</Hash>
</Codenesium>*/