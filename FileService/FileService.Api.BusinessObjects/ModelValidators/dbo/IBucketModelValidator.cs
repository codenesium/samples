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
    <Hash>c1c941d7a7d9380dd4d99f31cdf53742</Hash>
</Codenesium>*/