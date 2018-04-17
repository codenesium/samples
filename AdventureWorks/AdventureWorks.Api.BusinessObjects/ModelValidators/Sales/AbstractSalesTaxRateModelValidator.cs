using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractSalesTaxRateModelValidator: AbstractValidator<SalesTaxRateModel>
	{
		public new ValidationResult Validate(SalesTaxRateModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesTaxRateModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IStateProvinceRepository StateProvinceRepository { get; set; }
		public virtual void StateProvinceIDRules()
		{
			this.RuleFor(x => x.StateProvinceID).NotNull();
			this.RuleFor(x => x.StateProvinceID).Must(this.BeValidStateProvince).When(x => x ?.StateProvinceID != null).WithMessage("Invalid reference");
		}

		public virtual void TaxTypeRules()
		{
			this.RuleFor(x => x.TaxType).NotNull();
		}

		public virtual void TaxRateRules()
		{
			this.RuleFor(x => x.TaxRate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidStateProvince(int id)
		{
			return this.StateProvinceRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>1838633863f06e6d7e08e6dc68453fde</Hash>
</Codenesium>*/