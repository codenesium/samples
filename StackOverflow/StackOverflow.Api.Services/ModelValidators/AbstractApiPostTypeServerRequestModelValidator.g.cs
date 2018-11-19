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
	public abstract class AbstractApiPostTypeServerRequestModelValidator : AbstractValidator<ApiPostTypeServerRequestModel>
	{
		private int existingRecordId;

		private IPostTypeRepository postTypeRepository;

		public AbstractApiPostTypeServerRequestModelValidator(IPostTypeRepository postTypeRepository)
		{
			this.postTypeRepository = postTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostTypeServerRequestModel model, int id)
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
    <Hash>23e1e3338b0f360174ea36931e072ffb</Hash>
</Codenesium>*/