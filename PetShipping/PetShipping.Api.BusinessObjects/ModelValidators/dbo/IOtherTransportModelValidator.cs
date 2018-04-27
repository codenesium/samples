using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IOtherTransportModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(OtherTransportModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, OtherTransportModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>650f3a985acceee5823dbb7bd8436f01</Hash>
</Codenesium>*/