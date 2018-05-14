using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductDocumentModelValidator: AbstractApiProductDocumentModelValidator, IApiProductDocumentModelValidator
	{
		public ApiProductDocumentModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductDocumentModel model)
		{
			this.DocumentNodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDocumentModel model)
		{
			this.DocumentNodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>e89f869baf9a28b846f2d4108fb8820c</Hash>
</Codenesium>*/