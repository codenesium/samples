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

		private ILocationRepository locationRepository;

		public AbstractApiLocationServerRequestModelValidator(ILocationRepository locationRepository)
		{
			this.locationRepository = locationRepository;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiLocationServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueByName(ApiLocationServerRequestModel model,  CancellationToken cancellationToken)
		{
			Location record = await this.locationRepository.ByName(model.Name);

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
    <Hash>54cefc07102e41f4ee5405d790c33e02</Hash>
</Codenesium>*/