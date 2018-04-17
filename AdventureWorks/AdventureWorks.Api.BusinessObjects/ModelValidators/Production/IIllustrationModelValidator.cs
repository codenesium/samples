using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IIllustrationModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(IllustrationModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, IllustrationModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7201550a1a7e24a02320b6e01ef194af</Hash>
</Codenesium>*/