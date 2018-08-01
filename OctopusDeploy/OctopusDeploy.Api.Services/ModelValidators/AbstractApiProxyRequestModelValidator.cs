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
	public abstract class AbstractApiProxyRequestModelValidator : AbstractValidator<ApiProxyRequestModel>
	{
		private string existingRecordId;

		private IProxyRepository proxyRepository;

		public AbstractApiProxyRequestModelValidator(IProxyRepository proxyRepository)
		{
			this.proxyRepository = proxyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProxyRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProxyRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		private async Task<bool> BeUniqueByName(ApiProxyRequestModel model,  CancellationToken cancellationToken)
		{
			Proxy record = await this.proxyRepository.ByName(model.Name);

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
    <Hash>60c9212e3841fb52e2f2da3ad845f2bf</Hash>
</Codenesium>*/