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
	public abstract class AbstractApiProductListPriceHistoryRequestModelValidator: AbstractValidator<ApiProductListPriceHistoryRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiProductListPriceHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductListPriceHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>7950d1c18cc3ae21e9672bc3ee8e7b5d</Hash>
</Codenesium>*/