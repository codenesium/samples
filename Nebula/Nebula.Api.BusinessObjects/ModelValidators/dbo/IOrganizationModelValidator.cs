using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiOrganizationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOrganizationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8c05a101568fb1080c50aade04565c19</Hash>
</Codenesium>*/