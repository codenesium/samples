using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiCountryRegionModelValidator: AbstractValidator<ApiCountryRegionModel>
	{
		public new ValidationResult Validate(ApiCountryRegionModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRegionModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICountryRegionRepository CountryRegionRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCountryRegionModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private bool BeUniqueGetName(ApiCountryRegionModel model)
		{
			return this.CountryRegionRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>513515c6bb0fedd45015c300d35d8d54</Hash>
</Codenesium>*/