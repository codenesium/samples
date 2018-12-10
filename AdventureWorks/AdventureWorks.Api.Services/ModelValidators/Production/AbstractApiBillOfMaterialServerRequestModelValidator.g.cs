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
		}

		public virtual void StartDateRules()
		{
		}

		public virtual void UnitMeasureCodeRules()
		{
			this.RuleFor(x => x.UnitMeasureCode).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>505af56875de96be8263b9bac9d25cbc</Hash>
</Codenesium>*/