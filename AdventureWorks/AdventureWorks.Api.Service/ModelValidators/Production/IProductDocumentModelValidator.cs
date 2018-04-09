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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>db8401d342ac812ccfbf962f509c8dfb</Hash>
</Codenesium>*/