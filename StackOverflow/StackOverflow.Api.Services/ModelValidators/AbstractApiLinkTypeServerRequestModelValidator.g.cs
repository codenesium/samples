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

		public virtual void RwTypeRules()
		{
			this.RuleFor(x => x.RwType).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.RwType).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>d847931b4e41d1073f927039c6967f26</Hash>
</Codenesium>*/