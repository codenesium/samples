using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IApiBucketModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBucketModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c9a678419bf7d3f7054155649a738685</Hash>
</Codenesium>*/