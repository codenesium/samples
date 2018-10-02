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
	public abstract class AbstractApiTagRequestModelValidator : AbstractValidator<ApiTagRequestModel>
	{
		private int existingRecordId;

		private ITagRepository tagRepository;

		public AbstractApiTagRequestModelValidator(ITagRepository tagRepository)
		{
			this.tagRepository = tagRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTagRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountRules()
		{
		}

		public virtual void ExcerptPostIdRules()
		{
		}

		public virtual void TagNameRules()
		{
			this.RuleFor(x => x.TagName).NotNull();
			this.RuleFor(x => x.TagName).Length(0, 150);
		}

		public virtual void WikiPostIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a765bac74a9a04169cd3510aa50a8b2a</Hash>
</Codenesium>*/