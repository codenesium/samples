using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSpecialOfferProductRequestModelValidator: AbstractValidator<ApiSpecialOfferProductRequestModel>
	{
		public new ValidationResult Validate(ApiSpecialOfferProductRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpecialOfferProductRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISpecialOfferRepository SpecialOfferRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private async Task<bool> BeValidSpecialOffer(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SpecialOfferRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>8f6098c685c746cddf4ee485400e87c5</Hash>
</Codenesium>*/