using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiLocationRequestModelValidator: AbstractValidator<ApiLocationRequestModel>
	{
		private short existingRecordId;

		public new ValidationResult Validate(ApiLocationRequestModel model, short id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLocationRequestModel model, short id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public ILocationRepository LocationRepository { get; set; }
		public virtual void AvailabilityRules()
		{
			this.RuleFor(x => x.Availability).NotNull();
		}

		public virtual void CostRateRules()
		{
			this.RuleFor(x => x.CostRate).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLocationRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueGetName(ApiLocationRequestModel model,  CancellationToken cancellationToken)
		{
			Location record = await this.LocationRepository.GetName(model.Name);

			if(record == null || record.LocationID == this.existingRecordId)
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
    <Hash>3c2c1fd0411cdbbfbabfa1bd6bca872b</Hash>
</Codenesium>*/