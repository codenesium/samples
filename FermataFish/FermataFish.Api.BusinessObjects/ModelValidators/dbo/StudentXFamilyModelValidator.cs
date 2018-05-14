using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiStudentXFamilyModelValidator: AbstractApiStudentXFamilyModelValidator, IApiStudentXFamilyModelValidator
	{
		public ApiStudentXFamilyModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudentXFamilyModel model)
		{
			this.FamilyIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentXFamilyModel model)
		{
			this.FamilyIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>38ec15bed7cdc37ee1c863e074353221</Hash>
</Codenesium>*/