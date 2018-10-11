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
	public abstract class AbstractApiSpecialOfferProductRequestModelValidator : AbstractValidator<ApiSpecialOfferProductRequestModel>
	{
		private int existingRecordId;

		private ISpecialOfferProductRepository specialOfferProductRepository;

		public AbstractApiSpecialOfferProductRequestModelValidator(ISpecialOfferProductRepository specialOfferProductRepository)
		{
			this.specialOfferProductRepository = specialOfferProductRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpecialOfferProductRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ProductIDRules()
		{
		}

		public virtual void RowguidRules()
		{
		}

		private async Task<bool> BeValidSpecialOfferBySpecialOfferID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.specialOfferProductRepository.SpecialOfferBySpecialOfferID(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>45c12855dbb764b777b9626b03ccae78</Hash>
</Codenesium>*/