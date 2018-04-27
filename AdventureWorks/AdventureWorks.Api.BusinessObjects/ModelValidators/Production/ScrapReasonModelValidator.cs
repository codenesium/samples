using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ScrapReasonModelValidator: AbstractScrapReasonModelValidator, IScrapReasonModelValidator
	{
		public ScrapReasonModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ScrapReasonModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, ScrapReasonModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4a6ad1c7c78e2b319f2fe411831c3fb7</Hash>
</Codenesium>*/