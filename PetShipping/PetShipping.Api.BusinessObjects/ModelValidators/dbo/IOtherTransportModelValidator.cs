using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiOtherTransportModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7caf3e4d28672015a8f7658c72832b6d</Hash>
</Codenesium>*/