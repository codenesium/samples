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
    <Hash>e79fdfc9e03094c865910c79be4d6556</Hash>
</Codenesium>*/