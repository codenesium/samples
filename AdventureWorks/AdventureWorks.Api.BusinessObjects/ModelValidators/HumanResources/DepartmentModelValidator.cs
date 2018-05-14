using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiDepartmentModelValidator: AbstractApiDepartmentModelValidator, IApiDepartmentModelValidator
	{
		public ApiDepartmentModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiDepartmentModel model)
		{
			this.GroupNameRules();
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, ApiDepartmentModel model)
		{
			this.GroupNameRules();
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
    <Hash>e22ede719dacd9dadf74ca683a064cab</Hash>
</Codenesium>*/