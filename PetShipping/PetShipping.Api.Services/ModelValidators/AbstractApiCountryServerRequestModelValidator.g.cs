using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiCountryServerRequestModelValidator : AbstractValidator<ApiCountryServerRequestModel>
	{
		private int existingRecordId;

		private ICountryRepository countryRepository;

		public AbstractApiCountryServerRequestModelValidator(ICountryRepository countryRepository)
		{
			this.countryRepository = countryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>422db46a6db1f7a84e63613d9e341df3</Hash>
</Codenesium>*/