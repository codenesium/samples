using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiTeacherModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>24e132b853b47c57db973caf7129208a</Hash>
</Codenesium>*/