using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiCountryRequestModelValidator : AbstractValidator<ApiCountryRequestModel>
	{
		private int existingRecordId;

		private ICountryRepository countryRepository;

		public AbstractApiCountryRequestModelValidator(ICountryRepository countryRepository)
		{
			this.countryRepository = countryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>395ca75ce1d10924434bbb853243702f</Hash>
</Codenesium>*/