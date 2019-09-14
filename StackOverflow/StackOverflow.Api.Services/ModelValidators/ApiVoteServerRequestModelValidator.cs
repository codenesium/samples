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
	public class ApiVoteServerRequestModelValidator : AbstractValidator<ApiVoteServerRequestModel>, IApiVoteServerRequestModelValidator
	{
		private int existingRecordId;

		protected IVoteRepository VoteRepository { get; private set; }

		public ApiVoteServerRequestModelValidator(IVoteRepository voteRepository)
		{
			this.VoteRepository = voteRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVoteServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVoteServerRequestModel model)
		{
			this.BountyAmountRules();
			this.CreationDateRules();
			this.PostIdRules();
			this.UserIdRules();
			this.VoteTypeIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteServerRequestModel model)
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
    <Hash>ad957c015073fe56d728ec19dc4b88e4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/