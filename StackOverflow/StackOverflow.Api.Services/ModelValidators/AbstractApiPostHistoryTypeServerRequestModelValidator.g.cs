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
	public abstract class AbstractApiPostHistoryTypeServerRequestModelValidator : AbstractValidator<ApiPostHistoryTypeServerRequestModel>
	{
		private int existingRecordId;

		private IPostHistoryTypeRepository postHistoryTypeRepository;

		public AbstractApiPostHistoryTypeServerRequestModelValidator(IPostHistoryTypeRepository postHistoryTypeRepository)
		{
			this.postHistoryTypeRepository = postHistoryTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostHistoryTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void TypeRules()
		{
			this.RuleFor(x => x.Type).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Type).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>a6ebea67ff6444f430b3e2010e19849b</Hash>
</Codenesium>*/