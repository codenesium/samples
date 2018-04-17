using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class LessonXStudentModelValidator: AbstractLessonXStudentModelValidator, ILessonXStudentModelValidator
	{
		public LessonXStudentModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(LessonXStudentModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, LessonXStudentModel model)
		{
			this.LessonIdRules();
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
    <Hash>2d20e28fa468d227be1323272d40f4b1</Hash>
</Codenesium>*/