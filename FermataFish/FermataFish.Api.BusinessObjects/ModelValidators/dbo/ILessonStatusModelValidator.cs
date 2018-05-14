using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiLessonStatusModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonStatusModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonStatusModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b2df26503185b02e700b367166a3d40e</Hash>
</Codenesium>*/