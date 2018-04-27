using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractAirlineModelValidator: AbstractValidator<AirlineModel>
	{
		public new ValidationResult Validate(AirlineModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(AirlineModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>b87518b964e3512382469a07398b5650</Hash>
</Codenesium>*/