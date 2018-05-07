using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void BreedMapModelToEF(
			int id,
			BreedModel model,
			EFBreed efBreed)
		{
			efBreed.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOBreed BreedMapEFToPOCO(
			EFBreed efBreed)
		{
			if (efBreed == null)
			{
				return null;
			}

			return new POCOBreed(efBreed.Id, efBreed.Name);
		}

		public virtual void PaymentTypeMapModelToEF(
			int id,
			PaymentTypeModel model,
			EFPaymentType efPaymentType)
		{
			efPaymentType.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOPaymentType PaymentTypeMapEFToPOCO(
			EFPaymentType efPaymentType)
		{
			if (efPaymentType == null)
			{
				return null;
			}

			return new POCOPaymentType(efPaymentType.Id, efPaymentType.Name);
		}

		public virtual void PenMapModelToEF(
			int id,
			PenModel model,
			EFPen efPen)
		{
			efPen.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOPen PenMapEFToPOCO(
			EFPen efPen)
		{
			if (efPen == null)
			{
				return null;
			}

			return new POCOPen(efPen.Id, efPen.Name);
		}

		public virtual void PetMapModelToEF(
			int id,
			PetModel model,
			EFPet efPet)
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
			EFPet efPet)
		{
			if (efPet == null)
			{
				return null;
			}

			return new POCOPet(efPet.AcquiredDate, efPet.BreedId, efPet.Description, efPet.Id, efPet.PenId, efPet.Price, efPet.SpeciesId);
		}

		public virtual void SaleMapModelToEF(
			int id,
			SaleModel model,
			EFSale efSale)
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
			EFSale efSale)
		{
			if (efSale == null)
			{
				return null;
			}

			return new POCOSale(efSale.Amount, efSale.FirstName, efSale.Id, efSale.LastName, efSale.PaymentTypeId, efSale.PetId, efSale.Phone);
		}

		public virtual void SpeciesMapModelToEF(
			int id,
			SpeciesModel model,
			EFSpecies efSpecies)
		{
			efSpecies.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOSpecies SpeciesMapEFToPOCO(
			EFSpecies efSpecies)
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
    <Hash>bd0c46afc91e99fa3fddfe756c19d2c3</Hash>
</Codenesium>*/