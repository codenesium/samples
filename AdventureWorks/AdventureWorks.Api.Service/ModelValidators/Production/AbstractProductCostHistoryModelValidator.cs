using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductCostHistoryModelValidator: AbstractValidator<ProductCostHistoryModel>
	{
		public new ValidationResult Validate(ProductCostHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductCostHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void StartDateRules()
		{
			RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void StandardCostRules()
		{
			RuleFor(x => x.StandardCost).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>e8451be3e4b96201b2965f4a716dece4</Hash>
</Codenesium>*/