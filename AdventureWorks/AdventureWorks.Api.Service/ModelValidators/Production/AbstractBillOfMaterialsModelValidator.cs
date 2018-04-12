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

		public IProductRepository ProductRepository { get; set; }
		public IUnitMeasureRepository UnitMeasureRepository { get; set; }
		public virtual void ProductAssemblyIDRules()
		{
			this.RuleFor(x => x.ProductAssemblyID).Must(this.BeValidProduct).When(x => x ?.ProductAssemblyID != null).WithMessage("Invalid reference");
		}

		public virtual void ComponentIDRules()
		{
			this.RuleFor(x => x.ComponentID).NotNull();
			this.RuleFor(x => x.ComponentID).Must(this.BeValidProduct).When(x => x ?.ComponentID != null).WithMessage("Invalid reference");
		}

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void UnitMeasureCodeRules()
		{
			this.RuleFor(x => x.UnitMeasureCode).NotNull();
			this.RuleFor(x => x.UnitMeasureCode).Must(this.BeValidUnitMeasure).When(x => x ?.UnitMeasureCode != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
		}

		public virtual void BOMLevelRules()
		{
			this.RuleFor(x => x.BOMLevel).NotNull();
		}

		public virtual void PerAssemblyQtyRules()
		{
			this.RuleFor(x => x.PerAssemblyQty).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
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
    <Hash>32a117858ac899618c5feac409732c4e</Hash>
</Codenesium>*/