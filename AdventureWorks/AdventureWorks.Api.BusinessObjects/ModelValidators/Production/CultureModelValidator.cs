using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class CultureModelValidator: AbstractCultureModelValidator, ICultureModelValidator
	{
		public CultureModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(CultureModel model)
		{
			this.NameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, CultureModel model)
		{
			this.NameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>04db46453f77699727be582b7aad2949</Hash>
</Codenesium>*/