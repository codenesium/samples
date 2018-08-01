using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiVotesRequestModelValidator : AbstractValidator<ApiVotesRequestModel>
	{
		private int existingRecordId;

		private IVotesRepository votesRepository;

		public AbstractApiVotesRequestModelValidator(IVotesRepository votesRepository)
		{
			this.votesRepository = votesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVotesRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BountyAmountRules()
		{
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void PostIdRules()
		{
		}

		public virtual void UserIdRules()
		{
		}

		public virtual void VoteTypeIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>968b82215c66aecca685071033bb2523</Hash>
</Codenesium>*/