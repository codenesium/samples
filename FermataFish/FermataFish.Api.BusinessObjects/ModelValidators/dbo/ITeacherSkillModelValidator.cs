using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiTeacherSkillModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>83f9cfa743983f28cd76fdafc0d789d2</Hash>
</Codenesium>*/