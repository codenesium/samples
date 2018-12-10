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

		protected ILinkTypeRepository LinkTypeRepository { get; private set; }

		public AbstractApiLinkTypeServerRequestModelValidator(ILinkTypeRepository linkTypeRepository)
		{
			this.LinkTypeRepository = linkTypeRepository;
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
    <Hash>7f3bfe523b1eb7d4d6366fe11fcb830a</Hash>
</Codenesium>*/