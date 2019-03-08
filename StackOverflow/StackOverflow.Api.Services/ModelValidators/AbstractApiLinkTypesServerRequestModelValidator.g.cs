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
	public abstract class AbstractApiLinkTypesServerRequestModelValidator : AbstractValidator<ApiLinkTypesServerRequestModel>
	{
		private int existingRecordId;

		protected ILinkTypesRepository LinkTypesRepository { get; private set; }

		public AbstractApiLinkTypesServerRequestModelValidator(ILinkTypesRepository linkTypesRepository)
		{
			this.LinkTypesRepository = linkTypesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkTypesServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void RwTypeRules()
		{
			this.RuleFor(x => x.RwType).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.RwType).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>66ce9ec176ce1ffb53848047fcf3fe98</Hash>
</Codenesium>*/