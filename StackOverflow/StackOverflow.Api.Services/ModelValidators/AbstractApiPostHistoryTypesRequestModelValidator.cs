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
	public abstract class AbstractApiPostHistoryTypesRequestModelValidator : AbstractValidator<ApiPostHistoryTypesRequestModel>
	{
		private int existingRecordId;

		private IPostHistoryTypesRepository postHistoryTypesRepository;

		public AbstractApiPostHistoryTypesRequestModelValidator(IPostHistoryTypesRepository postHistoryTypesRepository)
		{
			this.postHistoryTypesRepository = postHistoryTypesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostHistoryTypesRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void TypeRules()
		{
			this.RuleFor(x => x.Type).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>3763f7da54aa2762fca0dd8cbd6c9fad</Hash>
</Codenesium>*/