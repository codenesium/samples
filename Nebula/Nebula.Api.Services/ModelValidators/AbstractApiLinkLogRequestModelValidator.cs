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
	public abstract class AbstractApiLinkLogRequestModelValidator : AbstractValidator<ApiLinkLogRequestModel>
	{
		private int existingRecordId;

		private ILinkLogRepository linkLogRepository;

		public AbstractApiLinkLogRequestModelValidator(ILinkLogRepository linkLogRepository)
		{
			this.linkLogRepository = linkLogRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkLogRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DateEnteredRules()
		{
		}

		public virtual void LinkIdRules()
		{
			this.RuleFor(x => x.LinkId).MustAsync(this.BeValidLinkByLinkId).When(x => x?.LinkId != null).WithMessage("Invalid reference");
		}

		public virtual void LogRules()
		{
			this.RuleFor(x => x.Log).NotNull();
			this.RuleFor(x => x.Log).Length(0, 2147483647);
		}

		private async Task<bool> BeValidLinkByLinkId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.linkLogRepository.LinkByLinkId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>4816925ff8c5ad01f925e539edcd5659</Hash>
</Codenesium>*/