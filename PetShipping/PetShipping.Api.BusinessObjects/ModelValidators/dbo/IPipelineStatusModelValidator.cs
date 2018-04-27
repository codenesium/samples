using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStatusModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PipelineStatusModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PipelineStatusModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5aa28c98799b5218f05f96597361b21e</Hash>
</Codenesium>*/