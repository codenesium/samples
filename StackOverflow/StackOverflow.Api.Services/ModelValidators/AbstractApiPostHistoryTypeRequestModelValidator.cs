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
	public abstract class AbstractApiPostHistoryTypeRequestModelValidator : AbstractValidator<ApiPostHistoryTypeRequestModel>
	{
		private int existingRecordId;

		private IPostHistoryTypeRepository postHistoryTypeRepository;

		public AbstractApiPostHistoryTypeRequestModelValidator(IPostHistoryTypeRepository postHistoryTypeRepository)
		{
			this.postHistoryTypeRepository = postHistoryTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostHistoryTypeRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void TypeRules()
		{
			this.RuleFor(x => x.Type).NotNull();
			this.RuleFor(x => x.Type).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>acea310b2fcabe9095a26ae8aeba6c3b</Hash>
</Codenesium>*/