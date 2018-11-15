using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiAirlineServerRequestModelValidator : AbstractValidator<ApiAirlineServerRequestModel>
	{
		private int existingRecordId;

		private IAirlineRepository airlineRepository;

		public AbstractApiAirlineServerRequestModelValidator(IAirlineRepository airlineRepository)
		{
			this.airlineRepository = airlineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAirlineServerRequestModel model, int id)
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
    <Hash>f8641a4f2d6e1e397a354f942f0d33c0</Hash>
</Codenesium>*/