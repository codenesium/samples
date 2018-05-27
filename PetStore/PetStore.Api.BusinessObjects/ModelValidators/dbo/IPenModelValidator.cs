using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiPenRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPenRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPenRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>01b8a153cf641fe5e4c20aab3154ef49</Hash>
</Codenesium>*/