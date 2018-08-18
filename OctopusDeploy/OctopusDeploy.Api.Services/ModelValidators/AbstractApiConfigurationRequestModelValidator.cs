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
	public abstract class AbstractApiConfigurationRequestModelValidator : AbstractValidator<ApiConfigurationRequestModel>
	{
		private string existingRecordId;

		private IConfigurationRepository configurationRepository;

		public AbstractApiConfigurationRequestModelValidator(IConfigurationRepository configurationRepository)
		{
			this.configurationRepository = configurationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiConfigurationRequestModel model, string id)
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
    <Hash>c6845fc7bee504588610569a93f8714f</Hash>
</Codenesium>*/