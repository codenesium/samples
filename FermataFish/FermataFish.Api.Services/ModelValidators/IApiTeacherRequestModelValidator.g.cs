using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiTeacherRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>695067970848e1245d5f082cd10f598f</Hash>
</Codenesium>*/