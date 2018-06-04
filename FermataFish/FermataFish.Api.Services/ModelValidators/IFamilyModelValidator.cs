using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiFamilyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFamilyRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a8cbb0a6e8dd749fc04df858b85bb05b</Hash>
</Codenesium>*/