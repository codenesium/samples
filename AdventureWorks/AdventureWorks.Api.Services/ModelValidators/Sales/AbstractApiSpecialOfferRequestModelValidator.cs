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
	public abstract class AbstractApiSpecialOfferRequestModelValidator : AbstractValidator<ApiSpecialOfferRequestModel>
	{
		private int existingRecordId;

		private ISpecialOfferRepository specialOfferRepository;

		public AbstractApiSpecialOfferRequestModelValidator(ISpecialOfferRepository specialOfferRepository)
		{
			this.specialOfferRepository = specialOfferRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpecialOfferRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CategoryRules()
		{
			this.RuleFor(x => x.Category).NotNull();
			this.RuleFor(x => x.Category).Length(0, 50);
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 255);
		}

		public virtual void DiscountPctRules()
		{
		}

		public virtual void EndDateRules()
		{
		}

		public virtual void MaxQtyRules()
		{
		}

		public virtual void MinQtyRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
		}

		public virtual void StartDateRules()
		{
		}

		public virtual void TypeRules()
		{
			this.RuleFor(x => x.Type).NotNull();
			this.RuleFor(x => x.Type).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>0c6377b082328570fe8c5ab97f532daa</Hash>
</Codenesium>*/