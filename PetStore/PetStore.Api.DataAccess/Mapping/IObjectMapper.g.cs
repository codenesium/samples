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

		void BreedMapEFToPOCO(
			EFBreed efBreed,
			ApiResponse response);

		void PaymentTypeMapModelToEF(
			int id,
			PaymentTypeModel model,
			EFPaymentType efPaymentType);

		void PaymentTypeMapEFToPOCO(
			EFPaymentType efPaymentType,
			ApiResponse response);

		void PenMapModelToEF(
			int id,
			PenModel model,
			EFPen efPen);

		void PenMapEFToPOCO(
			EFPen efPen,
			ApiResponse response);

		void PetMapModelToEF(
			int id,
			PetModel model,
			EFPet efPet);

		void PetMapEFToPOCO(
			EFPet efPet,
			ApiResponse response);

		void SaleMapModelToEF(
			int id,
			SaleModel model,
			EFSale efSale);

		void SaleMapEFToPOCO(
			EFSale efSale,
			ApiResponse response);

		void SpeciesMapModelToEF(
			int id,
			SpeciesModel model,
			EFSpecies efSpecies);

		void SpeciesMapEFToPOCO(
			EFSpecies efSpecies,
			ApiResponse response);
	}
}

/*<Codenesium>
    <Hash>de3cf5885d0b00fb2cded06375f569a9</Hash>
</Codenesium>*/