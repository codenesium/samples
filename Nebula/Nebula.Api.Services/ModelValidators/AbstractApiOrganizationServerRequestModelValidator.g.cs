using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiOrganizationServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
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
    <Hash>973b550859935d90efed91a20c12051e</Hash>
</Codenesium>*/