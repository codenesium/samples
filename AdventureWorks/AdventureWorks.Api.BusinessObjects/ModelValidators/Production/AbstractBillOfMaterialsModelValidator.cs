using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractBillOfMaterialsModelValidator: AbstractValidator<BillOfMaterialsModel>
	{
		public new ValidationResult Validate(BillOfMaterialsModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(BillOfMaterialsModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void BOMLevelRules()
		{
			this.RuleFor(x => x.BOMLevel).NotNull();
		}

		public virtual void ComponentIDRules()
		{
			this.RuleFor(x => x.ComponentID).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PerAssemblyQtyRules()
		{
			this.RuleFor(x => x.PerAssemblyQty).NotNull();
		}

		public virtual void ProductAssemblyIDRules()
		{                       }

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void UnitMeasureCodeRules()
		{
			this.RuleFor(x => x.UnitMeasureCode).NotNull();
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
		}
	}
}

/*<Codenesium>
    <Hash>3fa7e6ec708a1e45a3be4a5077e25d8f</Hash>
</Codenesium>*/