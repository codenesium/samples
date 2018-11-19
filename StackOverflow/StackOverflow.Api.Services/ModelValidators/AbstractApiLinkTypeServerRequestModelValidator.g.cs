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
	public abstract class AbstractApiLinkTypeServerRequestModelValidator : AbstractValidator<ApiLinkTypeServerRequestModel>
	{
		private int existingRecordId;

		private ILinkTypeRepository linkTypeRepository;

		public AbstractApiLinkTypeServerRequestModelValidator(ILinkTypeRepository linkTypeRepository)
		{
			this.linkTypeRepository = linkTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkTypeServerRequestModel model, int id)
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
    <Hash>7a99fcf5721036739bce645e64d6095f</Hash>
</Codenesium>*/