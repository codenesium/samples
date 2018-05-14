using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiEmployeeModelValidator: AbstractValidator<ApiEmployeeModel>
	{
		public new ValidationResult Validate(ApiEmployeeModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 128);
		}

		public virtual void IsSalesPersonRules()
		{
			this.RuleFor(x => x.IsSalesPerson).NotNull();
		}

		public virtual void IsShipperRules()
		{
			this.RuleFor(x => x.IsShipper).NotNull();
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull();
			this.RuleFor(x => x.LastName).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>17d9a2469474ad0b1da31ecc3eb4161b</Hash>
</Codenesium>*/