using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void BreedMapModelToEF(
			int id,
			ApiBreedModel model,
			Breed efBreed)
		{
			efBreed.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOBreed BreedMapEFToPOCO(
			Breed efBreed)
		{
			if (efBreed == null)
			{
				return null;
			}

			return new POCOBreed(efBreed.Id, efBreed.Name);
		}

		public virtual void PaymentTypeMapModelToEF(
			int id,
			ApiPaymentTypeModel model,
			PaymentType efPaymentType)
		{
			efPaymentType.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOPaymentType PaymentTypeMapEFToPOCO(
			PaymentType efPaymentType)
		{
			if (efPaymentType == null)
			{
				return null;
			}

			return new POCOPaymentType(efPaymentType.Id, efPaymentType.Name);
		}

		public virtual void PenMapModelToEF(
			int id,
			ApiPenModel model,
			Pen efPen)
		{
			efPen.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOPen PenMapEFToPOCO(
			Pen efPen)
		{
			if (efPen == null)
			{
				return null;
			}

			return new POCOPen(efPen.Id, efPen.Name);
		}

		public virtual void PetMapModelToEF(
			int id,
			ApiPetModel model,
			Pet efPet)
		{
			efPet.SetProperties(
				id,
				model.AcquiredDate,
				model.BreedId,
				model.Description,
				model.PenId,
				model.Price,
				model.SpeciesId);
		}

		public virtual POCOPet PetMapEFToPOCO(
			Pet efPet)
		{
			if (efPet == null)
			{
				return null;
			}

			return new POCOPet(efPet.AcquiredDate, efPet.BreedId, efPet.Description, efPet.Id, efPet.PenId, efPet.Price, efPet.SpeciesId);
		}

		public virtual void SaleMapModelToEF(
			int id,
			ApiSaleModel model,
			Sale efSale)
		{
			efSale.SetProperties(
				id,
				model.Amount,
				model.FirstName,
				model.LastName,
				model.PaymentTypeId,
				model.PetId,
				model.Phone);
		}

		public virtual POCOSale SaleMapEFToPOCO(
			Sale efSale)
		{
			if (efSale == null)
			{
				return null;
			}

			return new POCOSale(efSale.Amount, efSale.FirstName, efSale.Id, efSale.LastName, efSale.PaymentTypeId, efSale.PetId, efSale.Phone);
		}

		public virtual void SpeciesMapModelToEF(
			int id,
			ApiSpeciesModel model,
			Species efSpecies)
		{
			efSpecies.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOSpecies SpeciesMapEFToPOCO(
			Species efSpecies)
		{
			if (efSpecies == null)
			{
				return null;
			}

			return new POCOSpecies(efSpecies.Id, efSpecies.Name);
		}
	}
}

/*<Codenesium>
    <Hash>e91c01d25d4db662facc3134a82bb246</Hash>
</Codenesium>*/