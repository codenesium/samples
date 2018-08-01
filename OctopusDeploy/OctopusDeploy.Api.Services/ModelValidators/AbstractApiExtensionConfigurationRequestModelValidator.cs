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
	public abstract class AbstractApiExtensionConfigurationRequestModelValidator : AbstractValidator<ApiExtensionConfigurationRequestModel>
	{
		private string existingRecordId;

		private IExtensionConfigurationRepository extensionConfigurationRepository;

		public AbstractApiExtensionConfigurationRequestModelValidator(IExtensionConfigurationRepository extensionConfigurationRepository)
		{
			this.extensionConfigurationRepository = extensionConfigurationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiExtensionConfigurationRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ExtensionAuthorRules()
		{
			this.RuleFor(x => x.ExtensionAuthor).Length(0, 1000);
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 1000);
		}
	}
}

/*<Codenesium>
    <Hash>2c20715a4d4bff79c64e3de4d50d6e37</Hash>
</Codenesium>*/