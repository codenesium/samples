using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiCountryRequirementModelValidator: AbstractValidator<ApiCountryRequirementModel>
	{
		public new ValidationResult Validate(ApiCountryRequirementModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRequirementModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICountryRepository CountryRepository { get; set; }
		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).NotNull();
			this.RuleFor(x => x.CountryId).Must(this.BeValidCountry).When(x => x ?.CountryId != null).WithMessage("Invalid reference");
		}

		public virtual void DetailsRules()
		{
			this.RuleFor(x => x.Details).NotNull();
			this.RuleFor(x => x.Details).Length(0, 2147483647);
		}

		private bool BeValidCountry(int id)
		{
			return this.CountryRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>fa6ed8bd850a7a5bd28e2c941a43abbd</Hash>
</Codenesium>*/