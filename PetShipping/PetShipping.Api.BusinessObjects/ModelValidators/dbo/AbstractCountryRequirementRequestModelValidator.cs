using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiCountryRequirementRequestModelValidator: AbstractValidator<ApiCountryRequirementRequestModel>
	{
		public new ValidationResult Validate(ApiCountryRequirementRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRequirementRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICountryRepository CountryRepository { get; set; }
		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).NotNull();
			this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountry).When(x => x ?.CountryId != null).WithMessage("Invalid reference");
		}

		public virtual void DetailsRules()
		{
			this.RuleFor(x => x.Details).NotNull();
			this.RuleFor(x => x.Details).Length(0, 2147483647);
		}

		private async Task<bool> BeValidCountry(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CountryRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>332fe4e3e39935a0165cf8e57ab5af92</Hash>
</Codenesium>*/