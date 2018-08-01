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
	public abstract class AbstractApiMutexRequestModelValidator : AbstractValidator<ApiMutexRequestModel>
	{
		private string existingRecordId;

		private IMutexRepository mutexRepository;

		public AbstractApiMutexRequestModelValidator(IMutexRepository mutexRepository)
		{
			this.mutexRepository = mutexRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMutexRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void JSONRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>618fd37f641ff7a4d189ea5ec57a58c2</Hash>
</Codenesium>*/