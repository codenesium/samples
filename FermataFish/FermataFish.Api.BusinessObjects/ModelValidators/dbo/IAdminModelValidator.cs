using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiAdminModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAdminModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4df2915f31d8061ec5ba7370fe378bc5</Hash>
</Codenesium>*/