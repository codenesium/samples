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
	public abstract class AbstractApiPostLinkServerRequestModelValidator : AbstractValidator<ApiPostLinkServerRequestModel>
	{
		private int existingRecordId;

		protected IPostLinkRepository PostLinkRepository { get; private set; }

		public AbstractApiPostLinkServerRequestModelValidator(IPostLinkRepository postLinkRepository)
		{
			this.PostLinkRepository = postLinkRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostLinkServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void LinkTypeIdRules()
		{
			this.RuleFor(x => x.LinkTypeId).MustAsync(this.BeValidLinkTypeByLinkTypeId).When(x => !x?.LinkTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PostIdRules()
		{
			this.RuleFor(x => x.PostId).MustAsync(this.BeValidPostByPostId).When(x => !x?.PostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void RelatedPostIdRules()
		{
			this.RuleFor(x => x.RelatedPostId).MustAsync(this.BeValidPostByRelatedPostId).When(x => !x?.RelatedPostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidLinkTypeByLinkTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostLinkRepository.LinkTypeByLinkTypeId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPostByPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostLinkRepository.PostByPostId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPostByRelatedPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostLinkRepository.PostByRelatedPostId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>facded0eda8c4f2163c12008407e4f87</Hash>
</Codenesium>*/