using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
    <Hash>b2bf3793a267c7196e49bd3724eecb1f</Hash>
</Codenesium>*/