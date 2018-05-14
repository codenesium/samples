using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductListPriceHistoryModelValidator: AbstractValidator<ApiProductListPriceHistoryModel>
	{
		public new ValidationResult Validate(ApiProductListPriceHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductListPriceHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void ListPriceRules()
		{
			this.RuleFor(x => x.ListPrice).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>cab22dbd47343d001b15756b30944487</Hash>
</Codenesium>*/