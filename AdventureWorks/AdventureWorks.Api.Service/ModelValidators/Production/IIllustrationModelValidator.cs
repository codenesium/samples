using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IIllustrationModelValidator
	{
		ValidationResult Validate(IllustrationModel entity);

		Task<ValidationResult> ValidateAsync(IllustrationModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>d4722c99048ae17b5941354f222602dc</Hash>
</Codenesium>*/