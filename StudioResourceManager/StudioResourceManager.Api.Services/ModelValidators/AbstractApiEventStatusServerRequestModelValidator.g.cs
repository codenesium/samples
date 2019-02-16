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
	public abstract class AbstractApiEventStatusServerRequestModelValidator : AbstractValidator<ApiEventStatusServerRequestModel>
	{
		private int existingRecordId;

		protected IEventStatusRepository EventStatusRepository { get; private set; }

		public AbstractApiEventStatusServerRequestModelValidator(IEventStatusRepository eventStatusRepository)
		{
			this.EventStatusRepository = eventStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventStatusServerRequestModel model, int id)
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
    <Hash>2d4e27d7184b9c4c2c6f93b75d454700</Hash>
</Codenesium>*/