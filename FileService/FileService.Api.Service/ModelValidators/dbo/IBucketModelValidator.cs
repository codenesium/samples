using System.Threading.Tasks;
using FluentValidation.Results;

using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.Service
{
	public interface IBucketModelValidator
	{
		ValidationResult Validate(BucketModel entity);

		Task<ValidationResult> ValidateAsync(BucketModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>8b2678573108ed22967202accc1805a2</Hash>
</Codenesium>*/