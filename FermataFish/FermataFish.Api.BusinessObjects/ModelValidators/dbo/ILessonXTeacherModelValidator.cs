using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ILessonXTeacherModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LessonXTeacherModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LessonXTeacherModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4cbe15f931a268e0fc19c18730fafab5</Hash>
</Codenesium>*/