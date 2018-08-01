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
	public abstract class AbstractApiAirlineRequestModelValidator : AbstractValidator<ApiAirlineRequestModel>
	{
		private int existingRecordId;

		private IAirlineRepository airlineRepository;

		public AbstractApiAirlineRequestModelValidator(IAirlineRepository airlineRepository)
		{
			this.airlineRepository = airlineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAirlineRequestModel model, int id)
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
    <Hash>ceaba5e0d80f6ca0510f963b35221352</Hash>
</Codenesium>*/