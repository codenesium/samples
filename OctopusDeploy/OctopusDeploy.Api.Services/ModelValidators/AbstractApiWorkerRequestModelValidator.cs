using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractApiWorkerRequestModelValidator : AbstractValidator<ApiWorkerRequestModel>
	{
		private string existingRecordId;

		private IWorkerRepository workerRepository;

		public AbstractApiWorkerRequestModelValidator(IWorkerRepository workerRepository)
		{
			this.workerRepository = workerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiWorkerRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CommunicationStyleRules()
		{
			this.RuleFor(x => x.CommunicationStyle).Length(0, 50);
		}

		public virtual void FingerprintRules()
		{
			this.RuleFor(x => x.Fingerprint).Length(0, 50);
		}

		public virtual void IsDisabledRules()
		{
		}

		public virtual void JSONRules()
		{
		}

		public virtual void MachinePolicyIdRules()
		{
			this.RuleFor(x => x.MachinePolicyId).Length(0, 50);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiWorkerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		public virtual void RelatedDocumentIdsRules()
		{
		}

		public virtual void ThumbprintRules()
		{
			this.RuleFor(x => x.Thumbprint).Length(0, 50);
		}

		public virtual void WorkerPoolIdsRules()
		{
		}

		private async Task<bool> BeUniqueByName(ApiWorkerRequestModel model,  CancellationToken cancellationToken)
		{
			Worker record = await this.workerRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
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
    <Hash>4307e47a9e99e1a62a521390f16e48db</Hash>
</Codenesium>*/