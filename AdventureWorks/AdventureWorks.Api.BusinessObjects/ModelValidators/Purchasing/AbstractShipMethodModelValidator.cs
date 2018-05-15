using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiShipMethodModelValidator: AbstractValidator<ApiShipMethodModel>
	{
		public new ValidationResult Validate(ApiShipMethodModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiShipMethodModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IShipMethodRepository ShipMethodRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint");
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ShipBaseRules()
		{
			this.RuleFor(x => x.ShipBase).NotNull();
		}

		public virtual void ShipRateRules()
		{
			this.RuleFor(x => x.ShipRate).NotNull();
		}

		private bool BeUniqueGetName(ApiShipMethodModel model)
		{
			return this.ShipMethodRepository.GetName(model.Name) != null;
		}
	}
}

/*<Codenesium>
    <Hash>5ea6c6ded39033ad291e4c712f980e38</Hash>
</Codenesium>*/