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
	public abstract class AbstractApiWorkerTaskLeaseRequestModelValidator : AbstractValidator<ApiWorkerTaskLeaseRequestModel>
	{
		private string existingRecordId;

		private IWorkerTaskLeaseRepository workerTaskLeaseRepository;

		public AbstractApiWorkerTaskLeaseRequestModelValidator(IWorkerTaskLeaseRepository workerTaskLeaseRepository)
		{
			this.workerTaskLeaseRepository = workerTaskLeaseRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiWorkerTaskLeaseRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ExclusiveRules()
		{
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		public virtual void TaskIdRules()
		{
			this.RuleFor(x => x.TaskId).Length(0, 50);
		}

		public virtual void WorkerIdRules()
		{
			this.RuleFor(x => x.WorkerId).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>fd34747e09770d43e6c28c4d39d2f125</Hash>
</Codenesium>*/