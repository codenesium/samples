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
	public abstract class AbstractApiEmployeeRequestModelValidator: AbstractValidator<ApiEmployeeRequestModel>
	{
		public new ValidationResult Validate(ApiEmployeeRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeRequestModel model)
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
    <Hash>8e4e4a881eecba8e61dd27dd831e65fe</Hash>
</Codenesium>*/