using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractEmployeeModelValidator: AbstractValidator<EmployeeModel>
	{
		public new ValidationResult Validate(EmployeeModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(EmployeeModel model)
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
    <Hash>dd7ac42773c3ff822e0f54b9cb34e6a8</Hash>
</Codenesium>*/