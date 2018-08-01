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
	public abstract class AbstractApiKeyAllocationRequestModelValidator : AbstractValidator<ApiKeyAllocationRequestModel>
	{
		private string existingRecordId;

		private IKeyAllocationRepository keyAllocationRepository;

		public AbstractApiKeyAllocationRequestModelValidator(IKeyAllocationRepository keyAllocationRepository)
		{
			this.keyAllocationRepository = keyAllocationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiKeyAllocationRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AllocatedRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>24a577661f0e3dff4e27795c20c99c4c</Hash>
</Codenesium>*/