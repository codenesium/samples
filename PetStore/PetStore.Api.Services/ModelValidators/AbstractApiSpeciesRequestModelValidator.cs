using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>641c0a70736368b93337279580415da5</Hash>
</Codenesium>*/