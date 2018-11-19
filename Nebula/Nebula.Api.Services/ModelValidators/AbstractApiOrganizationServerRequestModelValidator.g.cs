using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiOrganizationServerRequestModelValidator : AbstractValidator<ApiOrganizationServerRequestModel>
	{
		private int existingRecordId;

		private IOrganizationRepository organizationRepository;

		public AbstractApiOrganizationServerRequestModelValidator(IOrganizationRepository organizationRepository)
		{
			this.organizationRepository = organizationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiOrganizationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiOrganizationServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		private async Task<bool> BeUniqueByName(ApiOrganizationServerRequestModel model,  CancellationToken cancellationToken)
		{
			Organization record = await this.organizationRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>68f9e86821a76c27374931c59456802b</Hash>
</Codenesium>*/