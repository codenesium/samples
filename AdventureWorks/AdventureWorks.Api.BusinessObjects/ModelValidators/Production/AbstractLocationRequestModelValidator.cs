using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiLocationRequestModelValidator: AbstractValidator<ApiLocationRequestModel>
	{
		public new ValidationResult Validate(ApiLocationRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLocationRequestModel model)
		{
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
			var record = await this.LocationRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>09a72823acd36f8429372ec17b7433e9</Hash>
</Codenesium>*/