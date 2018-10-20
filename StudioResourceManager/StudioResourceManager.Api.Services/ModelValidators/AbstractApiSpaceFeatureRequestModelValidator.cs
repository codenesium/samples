using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiSpaceFeatureRequestModelValidator : AbstractValidator<ApiSpaceFeatureRequestModel>
	{
		private int existingRecordId;

		private ISpaceFeatureRepository spaceFeatureRepository;

		public AbstractApiSpaceFeatureRequestModelValidator(ISpaceFeatureRepository spaceFeatureRepository)
		{
			this.spaceFeatureRepository = spaceFeatureRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpaceFeatureRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void IsDeletedRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8e1251943c687d7beb27a5b0c1094813</Hash>
</Codenesium>*/