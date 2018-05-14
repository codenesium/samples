using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiIllustrationModelValidator: AbstractApiIllustrationModelValidator, IApiIllustrationModelValidator
	{
		public ApiIllustrationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiIllustrationModel model)
		{
			this.DiagramRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationModel model)
		{
			this.DiagramRules();
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
    <Hash>239a962a1409938d685dfdb5491f564b</Hash>
</Codenesium>*/