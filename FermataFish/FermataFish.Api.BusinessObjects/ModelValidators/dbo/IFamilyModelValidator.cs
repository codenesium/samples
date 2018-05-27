using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiFamilyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFamilyRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6b1835a986325d6d41cfcf7cc7f54644</Hash>
</Codenesium>*/