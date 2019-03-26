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
	public abstract class AbstractApiBillOfMaterialServerRequestModelValidator : AbstractValidator<ApiBillOfMaterialServerRequestModel>
	{
		private int existingRecordId;

		protected IBillOfMaterialRepository BillOfMaterialRepository { get; private set; }

		public AbstractApiBillOfMaterialServerRequestModelValidator(IBillOfMaterialRepository billOfMaterialRepository)
		{
			this.BillOfMaterialRepository = billOfMaterialRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBillOfMaterialServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BOMLevelRules()
		{
		}

		public virtual void ComponentIDRules()
		{
			this.RuleFor(x => x.ComponentID).MustAsync(this.BeValidProductByComponentID).When(x => !x?.ComponentID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
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
			this.RuleFor(x => x.ProductAssemblyID).MustAsync(this.BeValidProductByProductAssemblyID).When(x => !x?.ProductAssemblyID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void StartDateRules()
		{
		}

		public virtual void UnitMeasureCodeRules()
		{
			this.RuleFor(x => x.UnitMeasureCode).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.UnitMeasureCode).MustAsync(this.BeValidUnitMeasureByUnitMeasureCode).When(x => !x?.UnitMeasureCode.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidProductByComponentID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.BillOfMaterialRepository.ProductByComponentID(id);

			return record != null;
		}

		protected async Task<bool> BeValidProductByProductAssemblyID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.BillOfMaterialRepository.ProductByProductAssemblyID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidUnitMeasureByUnitMeasureCode(string id,  CancellationToken cancellationToken)
		{
			var record = await this.BillOfMaterialRepository.UnitMeasureByUnitMeasureCode(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>ab81ba2a461072fe14dee74236708e37</Hash>
</Codenesium>*/