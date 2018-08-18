using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiStudentXFamilyRequestModelValidator : AbstractApiStudentXFamilyRequestModelValidator, IApiStudentXFamilyRequestModelValidator
	{
		public ApiStudentXFamilyRequestModelValidator(IStudentXFamilyRepository studentXFamilyRepository)
			: base(studentXFamilyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudentXFamilyRequestModel model)
		{
			this.FamilyIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentXFamilyRequestModel model)
		{
			this.FamilyIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>5cb3debba771bc46563851f5c1e91a5d</Hash>
</Codenesium>*/