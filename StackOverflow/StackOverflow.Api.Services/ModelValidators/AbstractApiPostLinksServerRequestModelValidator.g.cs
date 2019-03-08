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
	public abstract class AbstractApiPostLinksServerRequestModelValidator : AbstractValidator<ApiPostLinksServerRequestModel>
	{
		private int existingRecordId;

		protected IPostLinksRepository PostLinksRepository { get; private set; }

		public AbstractApiPostLinksServerRequestModelValidator(IPostLinksRepository postLinksRepository)
		{
			this.PostLinksRepository = postLinksRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostLinksServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void LinkTypeIdRules()
		{
			this.RuleFor(x => x.LinkTypeId).MustAsync(this.BeValidLinkTypesByLinkTypeId).When(x => !x?.LinkTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PostIdRules()
		{
			this.RuleFor(x => x.PostId).MustAsync(this.BeValidPostsByPostId).When(x => !x?.PostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void RelatedPostIdRules()
		{
			this.RuleFor(x => x.RelatedPostId).MustAsync(this.BeValidPostsByRelatedPostId).When(x => !x?.RelatedPostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidLinkTypesByLinkTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostLinksRepository.LinkTypesByLinkTypeId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPostsByPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostLinksRepository.PostsByPostId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPostsByRelatedPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostLinksRepository.PostsByRelatedPostId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>369a638f9ed8163063a06c30b4ac6608</Hash>
</Codenesium>*/