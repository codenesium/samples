using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductDocumentRequestModelValidator: AbstractApiProductDocumentRequestModelValidator, IApiProductDocumentRequestModelValidator
	{
		public ApiProductDocumentRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductDocumentRequestModel model)
		{
			this.DocumentNodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDocumentRequestModel model)
		{
			this.DocumentNodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c9b94de2789d0dcefe6c0d3a2fcaf3bc</Hash>
</Codenesium>*/