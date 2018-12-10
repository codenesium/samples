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
	public abstract class AbstractApiVoteServerRequestModelValidator : AbstractValidator<ApiVoteServerRequestModel>
	{
		private int existingRecordId;

		protected IVoteRepository VoteRepository { get; private set; }

		public AbstractApiVoteServerRequestModelValidator(IVoteRepository voteRepository)
		{
			this.VoteRepository = voteRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVoteServerRequestModel model, int id)
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
    <Hash>16b2b7ae290b26eb4b61ca6c80b80a90</Hash>
</Codenesium>*/