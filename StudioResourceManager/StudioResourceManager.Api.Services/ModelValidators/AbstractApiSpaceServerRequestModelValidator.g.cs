using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiSpaceServerRequestModelValidator : AbstractValidator<ApiSpaceServerRequestModel>
	{
		private int existingRecordId;

		private ISpaceRepository spaceRepository;

		public AbstractApiSpaceServerRequestModelValidator(ISpaceRepository spaceRepository)
		{
			this.spaceRepository = spaceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpaceServerRequestModel model, int id)
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
	}
}

/*<Codenesium>
    <Hash>bfdd1a23c365c1f7b6c94dfa410a46d8</Hash>
</Codenesium>*/