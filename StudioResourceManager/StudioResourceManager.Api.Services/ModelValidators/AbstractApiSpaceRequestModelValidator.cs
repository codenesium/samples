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
	public abstract class AbstractApiSpaceRequestModelValidator : AbstractValidator<ApiSpaceRequestModel>
	{
		private int existingRecordId;

		private ISpaceRepository spaceRepository;

		public AbstractApiSpaceRequestModelValidator(ISpaceRepository spaceRepository)
		{
			this.spaceRepository = spaceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpaceRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 128);
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
    <Hash>9f35bb451e20cf82457d1ac881ea544c</Hash>
</Codenesium>*/