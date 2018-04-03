using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public virtual void ProductAssemblyIDRules()
		{                       }

		public virtual void ComponentIDRules()
		{
			RuleFor(x => x.ComponentID).NotNull();
		}

		public virtual void StartDateRules()
		{
			RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void UnitMeasureCodeRules()
		{
			RuleFor(x => x.UnitMeasureCode).NotNull();
			RuleFor(x => x.UnitMeasureCode).Length(0,3);
		}

		public virtual void BOMLevelRules()
		{
			RuleFor(x => x.BOMLevel).NotNull();
		}

		public virtual void PerAssemblyQtyRules()
		{
			RuleFor(x => x.PerAssemblyQty).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>13c1de8b514dc70dadc2c224254a1be2</Hash>
</Codenesium>*/