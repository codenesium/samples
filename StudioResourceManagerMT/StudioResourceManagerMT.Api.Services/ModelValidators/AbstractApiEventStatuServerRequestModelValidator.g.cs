using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiEventStatuServerRequestModelValidator : AbstractValidator<ApiEventStatuServerRequestModel>
	{
		private int existingRecordId;

		private IEventStatuRepository eventStatuRepository;

		public AbstractApiEventStatuServerRequestModelValidator(IEventStatuRepository eventStatuRepository)
		{
			this.eventStatuRepository = eventStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventStatuServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>990ecdb58a09e890c3eb192828148255</Hash>
</Codenesium>*/