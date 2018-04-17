using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBucketModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(BucketModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, BucketModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f65a88f28731ee8d18cf79cad4ebf263</Hash>
</Codenesium>*/