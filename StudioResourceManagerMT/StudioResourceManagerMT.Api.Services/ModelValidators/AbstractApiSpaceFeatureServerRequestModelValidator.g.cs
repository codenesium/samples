using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiSpaceFeatureServerRequestModelValidator : AbstractValidator<ApiSpaceFeatureServerRequestModel>
	{
		private int existingRecordId;

		private ISpaceFeatureRepository spaceFeatureRepository;

		public AbstractApiSpaceFeatureServerRequestModelValidator(ISpaceFeatureRepository spaceFeatureRepository)
		{
			this.spaceFeatureRepository = spaceFeatureRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpaceFeatureServerRequestModel model, int id)
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
    <Hash>09f81c856dbf142da6444fc0215d5e1f</Hash>
</Codenesium>*/