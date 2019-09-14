using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiSpaceSpaceFeatureServerRequestModelValidator : AbstractValidator<ApiSpaceSpaceFeatureServerRequestModel>, IApiSpaceSpaceFeatureServerRequestModelValidator
	{
		private int existingRecordId;

		protected ISpaceSpaceFeatureRepository SpaceSpaceFeatureRepository { get; private set; }

		public ApiSpaceSpaceFeatureServerRequestModelValidator(ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository)
		{
			this.SpaceSpaceFeatureRepository = spaceSpaceFeatureRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpaceSpaceFeatureServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceSpaceFeatureServerRequestModel model)
		{
			this.SpaceFeatureIdRules();
			this.SpaceIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceSpaceFeatureServerRequestModel model)
		{
			this.SpaceFeatureIdRules();
			this.SpaceIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void SpaceFeatureIdRules()
		{
			this.RuleFor(x => x.SpaceFeatureId).MustAsync(this.BeValidSpaceFeatureBySpaceFeatureId).When(x => !x?.SpaceFeatureId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void SpaceIdRules()
		{
			this.RuleFor(x => x.SpaceId).MustAsync(this.BeValidSpaceBySpaceId).When(x => !x?.SpaceId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidSpaceFeatureBySpaceFeatureId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SpaceSpaceFeatureRepository.SpaceFeatureBySpaceFeatureId(id);

			return record != null;
		}

		protected async Task<bool> BeValidSpaceBySpaceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SpaceSpaceFeatureRepository.SpaceBySpaceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>cf4f636d11f8978209dfdbcebc887e9a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/