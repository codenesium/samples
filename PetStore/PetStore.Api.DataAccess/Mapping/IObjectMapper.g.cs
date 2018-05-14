using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void BreedMapModelToEF(
			int id,
			ApiBreedModel model,
			Breed efBreed);

		POCOBreed BreedMapEFToPOCO(
			Breed efBreed);

		void PaymentTypeMapModelToEF(
			int id,
			ApiPaymentTypeModel model,
			PaymentType efPaymentType);

		POCOPaymentType PaymentTypeMapEFToPOCO(
			PaymentType efPaymentType);

		void PenMapModelToEF(
			int id,
			ApiPenModel model,
			Pen efPen);

		POCOPen PenMapEFToPOCO(
			Pen efPen);

		void PetMapModelToEF(
			int id,
			ApiPetModel model,
			Pet efPet);

		POCOPet PetMapEFToPOCO(
			Pet efPet);

		void SaleMapModelToEF(
			int id,
			ApiSaleModel model,
			Sale efSale);

		POCOSale SaleMapEFToPOCO(
			Sale efSale);

		void SpeciesMapModelToEF(
			int id,
			ApiSpeciesModel model,
			Species efSpecies);

		POCOSpecies SpeciesMapEFToPOCO(
			Species efSpecies);
	}
}

/*<Codenesium>
    <Hash>560439f815a0b5c7d10a6e4702ec82e6</Hash>
</Codenesium>*/