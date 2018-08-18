using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiEventRelatedDocumentRequestModelValidator : AbstractApiEventRelatedDocumentRequestModelValidator, IApiEventRelatedDocumentRequestModelValidator
	{
		public ApiEventRelatedDocumentRequestModelValidator(IEventRelatedDocumentRepository eventRelatedDocumentRepository)
			: base(eventRelatedDocumentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventRelatedDocumentRequestModel model)
		{
			this.EventIdRules();
			this.RelatedDocumentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventRelatedDocumentRequestModel model)
		{
			this.EventIdRules();
			this.RelatedDocumentIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>e397590dd13fe2ec01b68341bb91063f</Hash>
</Codenesium>*/