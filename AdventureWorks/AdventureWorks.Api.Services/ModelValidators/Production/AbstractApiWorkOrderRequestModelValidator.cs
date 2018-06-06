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
	public abstract class AbstractApiWorkOrderRequestModelValidator: AbstractValidator<ApiWorkOrderRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiWorkOrderRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiWorkOrderRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void DueDateRules()
		{
			this.RuleFor(x => x.DueDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OrderQtyRules()
		{
			this.RuleFor(x => x.OrderQty).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void ScrappedQtyRules()
		{
			this.RuleFor(x => x.ScrappedQty).NotNull();
		}

		public virtual void ScrapReasonIDRules()
		{                       }

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void StockedQtyRules()
		{
			this.RuleFor(x => x.StockedQty).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>96a8affc5a991f636add77f72a605238</Hash>
</Codenesium>*/