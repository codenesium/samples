using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class TeacherXTeacherSkillModelValidator: AbstractTeacherXTeacherSkillModelValidator, ITeacherXTeacherSkillModelValidator
	{
		public TeacherXTeacherSkillModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(TeacherXTeacherSkillModel model)
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, TeacherXTeacherSkillModel model)
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>1e1506748010a11d4ecbcdc8bd834b8d</Hash>
</Codenesium>*/