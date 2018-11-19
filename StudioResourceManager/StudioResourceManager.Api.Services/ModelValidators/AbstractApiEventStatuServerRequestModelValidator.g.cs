using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>da2d42d694eec5df473b9d64298999f5</Hash>
</Codenesium>*/