using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IOtherTransportModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(OtherTransportModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, OtherTransportModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>89646191c5ad386ed48102be801c5804</Hash>
</Codenesium>*/