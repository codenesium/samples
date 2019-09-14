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
	public class ApiPostLinkServerRequestModelValidator : AbstractValidator<ApiPostLinkServerRequestModel>, IApiPostLinkServerRequestModelValidator
	{
		private int existingRecordId;

		protected IPostLinkRepository PostLinkRepository { get; private set; }

		public ApiPostLinkServerRequestModelValidator(IPostLinkRepository postLinkRepository)
		{
			this.PostLinkRepository = postLinkRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostLinkServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostLinkServerRequestModel model)
		{
			this.CreationDateRules();
			this.LinkTypeIdRules();
			this.PostIdRules();
			this.RelatedPostIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostLinkServerRequestModel model)
		{
			this.CreationDateRules();
			this.LinkTypeIdRules();
			this.PostIdRules();
			this.RelatedPostIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>ce04fa1d9e3fc9fadbc8d4420a55cef9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/