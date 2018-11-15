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

		private IBillOfMaterialRepository billOfMaterialRepository;

		public AbstractApiBillOfMaterialServerRequestModelValidator(IBillOfMaterialRepository billOfMaterialRepository)
		{
			this.billOfMaterialRepository = billOfMaterialRepository;
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
			this.RuleFor(x => x.UnitMeasureCode).NotNull();
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
		}
	}
}

/*<Codenesium>
    <Hash>11cab824e025666635ad463c0adcc6ed</Hash>
</Codenesium>*/