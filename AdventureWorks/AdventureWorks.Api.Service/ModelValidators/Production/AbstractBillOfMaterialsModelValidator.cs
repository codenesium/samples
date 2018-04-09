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

		public IProductRepository ProductRepository {get; set;}
		public IUnitMeasureRepository UnitMeasureRepository {get; set;}
		public virtual void ProductAssemblyIDRules()
		{
			RuleFor(x => x.ProductAssemblyID).Must(BeValidProduct).When(x => x ?.ProductAssemblyID != null).WithMessage("Invalid reference");
		}

		public virtual void ComponentIDRules()
		{
			RuleFor(x => x.ComponentID).NotNull();
			RuleFor(x => x.ComponentID).Must(BeValidProduct).When(x => x ?.ComponentID != null).WithMessage("Invalid reference");
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
			RuleFor(x => x.UnitMeasureCode).Must(BeValidUnitMeasure).When(x => x ?.UnitMeasureCode != null).WithMessage("Invalid reference");
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

		private bool BeValidProduct(Nullable<int> id)
		{
			return this.ProductRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidUnitMeasure(string id)
		{
			return this.UnitMeasureRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>3c59fadeccf9b60605da26e37164ced6</Hash>
</Codenesium>*/