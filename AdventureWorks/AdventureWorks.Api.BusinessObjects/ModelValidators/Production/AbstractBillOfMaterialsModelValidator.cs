using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiBillOfMaterialsModelValidator: AbstractValidator<ApiBillOfMaterialsModel>
	{
		public new ValidationResult Validate(ApiBillOfMaterialsModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBillOfMaterialsModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IBillOfMaterialsRepository BillOfMaterialsRepository { get; set; }
		public virtual void BOMLevelRules()
		{
			this.RuleFor(x => x.BOMLevel).NotNull();
		}

		public virtual void ComponentIDRules()
		{
			this.RuleFor(x => x.ComponentID).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetProductAssemblyIDComponentIDStartDate).When(x => x ?.ComponentID != null).WithMessage("Violates unique constraint");
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
		{
			this.RuleFor(x => x).Must(this.BeUniqueGetProductAssemblyIDComponentIDStartDate).When(x => x ?.ProductAssemblyID != null).WithMessage("Violates unique constraint");
		}

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetProductAssemblyIDComponentIDStartDate).When(x => x ?.StartDate != null).WithMessage("Violates unique constraint");
		}

		public virtual void UnitMeasureCodeRules()
		{
			this.RuleFor(x => x.UnitMeasureCode).NotNull();
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
		}

		private bool BeUniqueGetProductAssemblyIDComponentIDStartDate(ApiBillOfMaterialsModel model)
		{
			return this.BillOfMaterialsRepository.GetProductAssemblyIDComponentIDStartDate(model.ProductAssemblyID,model.ComponentID,model.StartDate) != null;
		}
	}
}

/*<Codenesium>
    <Hash>1a555992312d90f9c5264a16841cd775</Hash>
</Codenesium>*/