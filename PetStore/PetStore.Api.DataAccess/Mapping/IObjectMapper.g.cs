using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void BreedMapModelToEF(
			int id,
			BreedModel model,
			EFBreed efBreed);

		POCOBreed BreedMapEFToPOCO(
			EFBreed efBreed);

		void PaymentTypeMapModelToEF(
			int id,
			PaymentTypeModel model,
			EFPaymentType efPaymentType);

		POCOPaymentType PaymentTypeMapEFToPOCO(
			EFPaymentType efPaymentType);

		void PenMapModelToEF(
			int id,
			PenModel model,
			EFPen efPen);

		POCOPen PenMapEFToPOCO(
			EFPen efPen);

		void PetMapModelToEF(
			int id,
			PetModel model,
			EFPet efPet);

		POCOPet PetMapEFToPOCO(
			EFPet efPet);

		void SaleMapModelToEF(
			int id,
			SaleModel model,
			EFSale efSale);

		POCOSale SaleMapEFToPOCO(
			EFSale efSale);

		void SpeciesMapModelToEF(
			int id,
			SpeciesModel model,
			EFSpecies efSpecies);

		POCOSpecies SpeciesMapEFToPOCO(
			EFSpecies efSpecies);
	}
}

/*<Codenesium>
    <Hash>ac7719c1f2fcfa2a4c5750183be8df7b</Hash>
</Codenesium>*/