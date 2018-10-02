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
	public abstract class AbstractApiSysdiagramRequestModelValidator : AbstractValidator<ApiSysdiagramRequestModel>
	{
		private int existingRecordId;

		private ISysdiagramRepository sysdiagramRepository;

		public AbstractApiSysdiagramRequestModelValidator(ISysdiagramRepository sysdiagramRepository)
		{
			this.sysdiagramRepository = sysdiagramRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSysdiagramRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DefinitionRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByPrincipalIdName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSysdiagramRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void PrincipalIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByPrincipalIdName).When(x => x?.PrincipalId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSysdiagramRequestModel.PrincipalId));
		}

		public virtual void VersionRules()
		{
		}

		private async Task<bool> BeUniqueByPrincipalIdName(ApiSysdiagramRequestModel model,  CancellationToken cancellationToken)
		{
			Sysdiagram record = await this.sysdiagramRepository.ByPrincipalIdName(model.PrincipalId, model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.DiagramId == this.existingRecordId))
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
    <Hash>37c199f0ed1b552285f3b90630356e65</Hash>
</Codenesium>*/