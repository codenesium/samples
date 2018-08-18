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
    <Hash>1a8389f2734431e3503de83c19660d0f</Hash>
</Codenesium>*/