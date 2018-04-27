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

		public virtual void BreedMapEFToPOCO(
			EFBreed efBreed,
			ApiResponse response)
		{
			if (efBreed == null)
			{
				return;
			}

			response.AddBreed(new POCOBreed(efBreed.Id, efBreed.Name));
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

		public virtual void PaymentTypeMapEFToPOCO(
			EFPaymentType efPaymentType,
			ApiResponse response)
		{
			if (efPaymentType == null)
			{
				return;
			}

			response.AddPaymentType(new POCOPaymentType(efPaymentType.Id, efPaymentType.Name));
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

		public virtual void PenMapEFToPOCO(
			EFPen efPen,
			ApiResponse response)
		{
			if (efPen == null)
			{
				return;
			}

			response.AddPen(new POCOPen(efPen.Id, efPen.Name));
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

		public virtual void PetMapEFToPOCO(
			EFPet efPet,
			ApiResponse response)
		{
			if (efPet == null)
			{
				return;
			}

			response.AddPet(new POCOPet(efPet.AcquiredDate, efPet.BreedId, efPet.Description, efPet.Id, efPet.PenId, efPet.Price, efPet.SpeciesId));

			this.BreedMapEFToPOCO(efPet.Breed, response);

			this.PenMapEFToPOCO(efPet.Pen, response);

			this.SpeciesMapEFToPOCO(efPet.Species, response);
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

		public virtual void SaleMapEFToPOCO(
			EFSale efSale,
			ApiResponse response)
		{
			if (efSale == null)
			{
				return;
			}

			response.AddSale(new POCOSale(efSale.Amount, efSale.FirstName, efSale.Id, efSale.LastName, efSale.PaymentTypeId, efSale.PetId, efSale.Phone));

			this.PaymentTypeMapEFToPOCO(efSale.PaymentType, response);

			this.PetMapEFToPOCO(efSale.Pet, response);
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

		public virtual void SpeciesMapEFToPOCO(
			EFSpecies efSpecies,
			ApiResponse response)
		{
			if (efSpecies == null)
			{
				return;
			}

			response.AddSpecies(new POCOSpecies(efSpecies.Id, efSpecies.Name));
		}
	}
}

/*<Codenesium>
    <Hash>d2b530e49c21681f4a1bba0baf081072</Hash>
</Codenesium>*/