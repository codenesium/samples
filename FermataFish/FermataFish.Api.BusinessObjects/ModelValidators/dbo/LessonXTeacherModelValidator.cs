using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class LessonXTeacherModelValidator: AbstractLessonXTeacherModelValidator, ILessonXTeacherModelValidator
	{
		public LessonXTeacherModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(LessonXTeacherModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, LessonXTeacherModel model)
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
    <Hash>9387b06241588adea0f76116b188eca4</Hash>
</Codenesium>*/