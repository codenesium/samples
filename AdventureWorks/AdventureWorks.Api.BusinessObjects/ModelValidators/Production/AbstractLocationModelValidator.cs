using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiLocationModelValidator: AbstractValidator<ApiLocationModel>
	{
		public new ValidationResult Validate(ApiLocationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLocationModel model)
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
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLocationModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private bool BeUniqueGetName(ApiLocationModel model)
		{
			return this.LocationRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>2371fabbd51aa53ec714b6ac1c8a0db3</Hash>
</Codenesium>*/