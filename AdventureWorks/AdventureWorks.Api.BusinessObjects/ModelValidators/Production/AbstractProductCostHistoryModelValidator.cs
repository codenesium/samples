using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductCostHistoryModelValidator: AbstractValidator<ApiProductCostHistoryModel>
	{
		public new ValidationResult Validate(ApiProductCostHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductCostHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void StandardCostRules()
		{
			this.RuleFor(x => x.StandardCost).NotNull();
		}

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>9ecb8112ffc7d775eec32f0aeac84b74</Hash>
</Codenesium>*/