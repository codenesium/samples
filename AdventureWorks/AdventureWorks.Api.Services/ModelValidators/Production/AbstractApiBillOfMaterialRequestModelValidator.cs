using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiBillOfMaterialRequestModelValidator : AbstractValidator<ApiBillOfMaterialRequestModel>
	{
		private int existingRecordId;

		private IBillOfMaterialRepository billOfMaterialRepository;

		public AbstractApiBillOfMaterialRequestModelValidator(IBillOfMaterialRepository billOfMaterialRepository)
		{
			this.billOfMaterialRepository = billOfMaterialRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBillOfMaterialRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BOMLevelRules()
		{
		}

		public virtual void ComponentIDRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByProductAssemblyIDComponentIDStartDate).When(x => x?.ComponentID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialRequestModel.ComponentID));
		}

		public virtual void EndDateRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void PerAssemblyQtyRules()
		{
		}

		public virtual void ProductAssemblyIDRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByProductAssemblyIDComponentIDStartDate).When(x => x?.ProductAssemblyID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialRequestModel.ProductAssemblyID));
		}

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByProductAssemblyIDComponentIDStartDate).When(x => x?.StartDate != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialRequestModel.StartDate));
		}

		public virtual void UnitMeasureCodeRules()
		{
			this.RuleFor(x => x.UnitMeasureCode).NotNull();
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
		}

		private async Task<bool> BeUniqueByProductAssemblyIDComponentIDStartDate(ApiBillOfMaterialRequestModel model,  CancellationToken cancellationToken)
		{
			BillOfMaterial record = await this.billOfMaterialRepository.ByProductAssemblyIDComponentIDStartDate(model.ProductAssemblyID, model.ComponentID, model.StartDate);

			if (record == null || (this.existingRecordId != default(int) && record.BillOfMaterialsID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>7c6108a20d201f1ee42f90721f842e8b</Hash>
</Codenesium>*/