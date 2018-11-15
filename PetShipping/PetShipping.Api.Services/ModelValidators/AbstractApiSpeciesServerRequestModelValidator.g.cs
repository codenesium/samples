using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiSpeciesServerRequestModelValidator : AbstractValidator<ApiSpeciesServerRequestModel>
	{
		private int existingRecordId;

		private ISpeciesRepository speciesRepository;

		public AbstractApiSpeciesServerRequestModelValidator(ISpeciesRepository speciesRepository)
		{
			this.speciesRepository = speciesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpeciesServerRequestModel model, int id)
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
    <Hash>6347150ad3bf9d5001d47190326b4c69</Hash>
</Codenesium>*/