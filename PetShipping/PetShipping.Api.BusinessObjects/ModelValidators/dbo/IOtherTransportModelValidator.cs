using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiOtherTransportRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9709f0d3ab96fd6025815ee2125bddae</Hash>
</Codenesium>*/