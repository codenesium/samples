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
	public abstract class AbstractApiSpeciesRequestModelValidator : AbstractValidator<ApiSpeciesRequestModel>
	{
		private int existingRecordId;

		private ISpeciesRepository speciesRepository;

		public AbstractApiSpeciesRequestModelValidator(ISpeciesRepository speciesRepository)
		{
			this.speciesRepository = speciesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpeciesRequestModel model, int id)
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
    <Hash>075e4497fed1485557f8a3e71cc5cac6</Hash>
</Codenesium>*/