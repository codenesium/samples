using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiBillOfMaterialsRequestModelValidator: AbstractValidator<ApiBillOfMaterialsRequestModel>
	{
		public new ValidationResult Validate(ApiBillOfMaterialsRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBillOfMaterialsRequestModel model)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetProductAssemblyIDComponentIDStartDate).When(x => x ?.ComponentID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialsRequestModel.ComponentID));
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetProductAssemblyIDComponentIDStartDate).When(x => x ?.ProductAssemblyID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialsRequestModel.ProductAssemblyID));
		}

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetProductAssemblyIDComponentIDStartDate).When(x => x ?.StartDate != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialsRequestModel.StartDate));
		}

		public virtual void UnitMeasureCodeRules()
		{
			this.RuleFor(x => x.UnitMeasureCode).NotNull();
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
		}

		private async Task<bool> BeUniqueGetProductAssemblyIDComponentIDStartDate(ApiBillOfMaterialsRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.BillOfMaterialsRepository.GetProductAssemblyIDComponentIDStartDate(model.ProductAssemblyID,model.ComponentID,model.StartDate);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>d9e8760cfbffc7a16362a63dbab181c7</Hash>
</Codenesium>*/