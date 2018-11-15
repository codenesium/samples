using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiBreedServerRequestModelValidator : AbstractValidator<ApiBreedServerRequestModel>
	{
		private int existingRecordId;

		private IBreedRepository breedRepository;

		public AbstractApiBreedServerRequestModelValidator(IBreedRepository breedRepository)
		{
			this.breedRepository = breedRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBreedServerRequestModel model, int id)
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
    <Hash>83f9487166550b4b3f13af72c95b7799</Hash>
</Codenesium>*/