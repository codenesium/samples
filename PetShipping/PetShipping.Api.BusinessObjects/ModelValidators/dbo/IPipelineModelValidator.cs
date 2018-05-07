using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PipelineModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PipelineModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>278f85f7d72464d69c4a5e49da4c33ff</Hash>
</Codenesium>*/