using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractShipMethodModelValidator: AbstractValidator<ShipMethodModel>
	{
		public new ValidationResult Validate(ShipMethodModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ShipMethodModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ShipBaseRules()
		{
			this.RuleFor(x => x.ShipBase).NotNull();
		}

		public virtual void ShipRateRules()
		{
			this.RuleFor(x => x.ShipRate).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>31bd90431d70c0c134fbddbc019eed1d</Hash>
</Codenesium>*/