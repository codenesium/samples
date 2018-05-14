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
			Breed efBreed);

		POCOBreed BreedMapEFToPOCO(
			Breed efBreed);

		void PaymentTypeMapModelToEF(
			int id,
			PaymentTypeModel model,
			PaymentType efPaymentType);

		POCOPaymentType PaymentTypeMapEFToPOCO(
			PaymentType efPaymentType);

		void PenMapModelToEF(
			int id,
			PenModel model,
			Pen efPen);

		POCOPen PenMapEFToPOCO(
			Pen efPen);

		void PetMapModelToEF(
			int id,
			PetModel model,
			Pet efPet);

		POCOPet PetMapEFToPOCO(
			Pet efPet);

		void SaleMapModelToEF(
			int id,
			SaleModel model,
			Sale efSale);

		POCOSale SaleMapEFToPOCO(
			Sale efSale);

		void SpeciesMapModelToEF(
			int id,
			SpeciesModel model,
			Species efSpecies);

		POCOSpecies SpeciesMapEFToPOCO(
			Species efSpecies);
	}
}

/*<Codenesium>
    <Hash>0441da9434c3ac07b30ddf1a52311011</Hash>
</Codenesium>*/