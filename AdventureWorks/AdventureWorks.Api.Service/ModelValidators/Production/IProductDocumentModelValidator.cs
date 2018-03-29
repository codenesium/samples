using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductDocumentModelValidator
	{
		ValidationResult Validate(ProductDocumentModel entity);

		Task<ValidationResult> ValidateAsync(ProductDocumentModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>427f7f955b09c0b46c12c056fd0ce239</Hash>
</Codenesium>*/