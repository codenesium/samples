using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
    <Hash>e67889f9a2dea11c85fabbd7b97804df</Hash>
</Codenesium>*/