using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStatusModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PipelineStatusModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStatusModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a61af7369a0058a58204d48b7cf954f9</Hash>
</Codenesium>*/