using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class LessonStatusModelValidator: AbstractLessonStatusModelValidator, ILessonStatusModelValidator
	{
		public LessonStatusModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(LessonStatusModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, LessonStatusModel model)
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
    <Hash>e4aa81d03cf378a991b17d2ec7885a2d</Hash>
</Codenesium>*/