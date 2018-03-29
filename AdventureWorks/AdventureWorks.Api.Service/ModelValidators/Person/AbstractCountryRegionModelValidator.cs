using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractCountryRegionModelValidator: AbstractValidator<CountryRegionModel>
	{
		public new ValidationResult Validate(CountryRegionModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(CountryRegionModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>6fba092c547be2ea3091c37775d1d525</Hash>
</Codenesium>*/