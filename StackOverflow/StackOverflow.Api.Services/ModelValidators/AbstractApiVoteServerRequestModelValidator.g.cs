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
			this.RuleFor(x => x.PostId).MustAsync(this.BeValidPostByPostId).When(x => !x?.PostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void VoteTypeIdRules()
		{
			this.RuleFor(x => x.VoteTypeId).MustAsync(this.BeValidVoteTypeByVoteTypeId).When(x => !x?.VoteTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPostByPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VoteRepository.PostByPostId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUserByUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.VoteRepository.UserByUserId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidVoteTypeByVoteTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VoteRepository.VoteTypeByVoteTypeId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>e4fe0a75debea31e342428cbc5b2cbdd</Hash>
</Codenesium>*/