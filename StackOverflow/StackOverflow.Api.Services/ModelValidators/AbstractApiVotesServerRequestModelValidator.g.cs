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
	public abstract class AbstractApiVotesServerRequestModelValidator : AbstractValidator<ApiVotesServerRequestModel>
	{
		private int existingRecordId;

		protected IVotesRepository VotesRepository { get; private set; }

		public AbstractApiVotesServerRequestModelValidator(IVotesRepository votesRepository)
		{
			this.VotesRepository = votesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVotesServerRequestModel model, int id)
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
			this.RuleFor(x => x.PostId).MustAsync(this.BeValidPostsByPostId).When(x => !x?.PostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUsersByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void VoteTypeIdRules()
		{
			this.RuleFor(x => x.VoteTypeId).MustAsync(this.BeValidVoteTypesByVoteTypeId).When(x => !x?.VoteTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPostsByPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VotesRepository.PostsByPostId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUsersByUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.VotesRepository.UsersByUserId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidVoteTypesByVoteTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VotesRepository.VoteTypesByVoteTypeId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>4bf5f55c42f046de1165e5f51dbc7b96</Hash>
</Codenesium>*/