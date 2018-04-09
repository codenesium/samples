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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>f93af961d366bde40c7c974c3723d8bc</Hash>
</Codenesium>*/