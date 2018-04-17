using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class TeacherSkillModelValidator: AbstractTeacherSkillModelValidator, ITeacherSkillModelValidator
	{
		public TeacherSkillModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(TeacherSkillModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, TeacherSkillModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>2dad05abf5e5e3d78933d29b5d13a2c7</Hash>
</Codenesium>*/