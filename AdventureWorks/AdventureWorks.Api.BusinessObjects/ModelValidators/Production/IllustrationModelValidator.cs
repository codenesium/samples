using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class IllustrationModelValidator: AbstractIllustrationModelValidator, IIllustrationModelValidator
	{
		public IllustrationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(IllustrationModel model)
		{
			this.DiagramRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, IllustrationModel model)
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
    <Hash>497ba652e11411ea378aca872b5be129</Hash>
</Codenesium>*/