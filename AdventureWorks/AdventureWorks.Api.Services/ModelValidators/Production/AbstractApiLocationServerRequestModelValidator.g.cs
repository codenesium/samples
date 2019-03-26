using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiLocationServerRequestModelValidator : AbstractValidator<ApiLocationServerRequestModel>
	{
		private short existingRecordId;

		protected ILocationRepository LocationRepository { get; private set; }

		public AbstractApiLocationServerRequestModelValidator(ILocationRepository locationRepository)
		{
			this.LocationRepository = locationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLocationServerRequestModel model, short id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AvailabilityRules()
		{
		}

		public virtual void CostRateRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiLocationServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeUniqueByName(ApiLocationServerRequestModel model,  CancellationToken cancellationToken)
		{
			Location record = await this.LocationRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(short) && record.LocationID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>2e1ce13de99df414565296fc43a5db3f</Hash>
</Codenesium>*/