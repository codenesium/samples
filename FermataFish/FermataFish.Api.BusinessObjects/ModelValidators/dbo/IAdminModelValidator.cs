using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiAdminRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>786145b8781cfbaa8f6fdae6bc38009d</Hash>
</Codenesium>*/