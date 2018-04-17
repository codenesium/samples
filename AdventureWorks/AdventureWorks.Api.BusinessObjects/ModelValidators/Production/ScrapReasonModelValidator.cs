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
			this.NameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, ScrapReasonModel model)
		{
			this.NameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>2ac31bf690ffc09d204e98909c31409b</Hash>
</Codenesium>*/