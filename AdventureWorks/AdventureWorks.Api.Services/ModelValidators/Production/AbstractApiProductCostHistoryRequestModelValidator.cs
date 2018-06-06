using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiProductCostHistoryRequestModelValidator: AbstractValidator<ApiProductCostHistoryRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiProductCostHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductCostHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>435c90254ebd3b03f03ef2b9a561240e</Hash>
</Codenesium>*/