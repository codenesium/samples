using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Services
{
	public interface IApiOrganizationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOrganizationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7d3f4d81398f6bff64542ea3fe294686</Hash>
</Codenesium>*/