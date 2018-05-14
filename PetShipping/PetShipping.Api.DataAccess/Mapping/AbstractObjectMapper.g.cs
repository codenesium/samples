using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void AirlineMapModelToEF(
			int id,
			AirlineModel model,
			Airline efAirline)
		{
			efAirline.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOAirline AirlineMapEFToPOCO(
			Airline efAirline)
		{
			if (efAirline == null)
			{
				return null;
			}

			return new POCOAirline(efAirline.Id, efAirline.Name);
		}

		public virtual void AirTransportMapModelToEF(
			int airlineId,
			AirTransportModel model,
			AirTransport efAirTransport)
		{
			efAirTransport.SetProperties(
				airlineId,
				model.FlightNumber,
				model.HandlerId,
				model.Id,
				model.LandDate,
				model.PipelineStepId,
				model.TakeoffDate);
		}

		public virtual POCOAirTransport AirTransportMapEFToPOCO(
			AirTransport efAirTransport)
		{
			if (efAirTransport == null)
			{
				return null;
			}

			return new POCOAirTransport(efAirTransport.AirlineId, efAirTransport.FlightNumber, efAirTransport.HandlerId, efAirTransport.Id, efAirTransport.LandDate, efAirTransport.PipelineStepId, efAirTransport.TakeoffDate);
		}

		public virtual void BreedMapModelToEF(
			int id,
			BreedModel model,
			Breed efBreed)
		{
			efBreed.SetProperties(
				id,
				model.Name,
				model.SpeciesId);
		}

		public virtual POCOBreed BreedMapEFToPOCO(
			Breed efBreed)
		{
			if (efBreed == null)
			{
				return null;
			}

			return new POCOBreed(efBreed.Id, efBreed.Name, efBreed.SpeciesId);
		}

		public virtual void ClientMapModelToEF(
			int id,
			ClientModel model,
			Client efClient)
		{
			efClient.SetProperties(
				id,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Notes,
				model.Phone);
		}

		public virtual POCOClient ClientMapEFToPOCO(
			Client efClient)
		{
			if (efClient == null)
			{
				return null;
			}

			return new POCOClient(efClient.Email, efClient.FirstName, efClient.Id, efClient.LastName, efClient.Notes, efClient.Phone);
		}

		public virtual void ClientCommunicationMapModelToEF(
			int id,
			ClientCommunicationModel model,
			ClientCommunication efClientCommunication)
		{
			efClientCommunication.SetProperties(
				id,
				model.ClientId,
				model.DateCreated,
				model.EmployeeId,
				model.Notes);
		}

		public virtual POCOClientCommunication ClientCommunicationMapEFToPOCO(
			ClientCommunication efClientCommunication)
		{
			if (efClientCommunication == null)
			{
				return null;
			}

			return new POCOClientCommunication(efClientCommunication.ClientId, efClientCommunication.DateCreated, efClientCommunication.EmployeeId, efClientCommunication.Id, efClientCommunication.Notes);
		}

		public virtual void CountryMapModelToEF(
			int id,
			CountryModel model,
			Country efCountry)
		{
			efCountry.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOCountry CountryMapEFToPOCO(
			Country efCountry)
		{
			if (efCountry == null)
			{
				return null;
			}

			return new POCOCountry(efCountry.Id, efCountry.Name);
		}

		public virtual void CountryRequirementMapModelToEF(
			int id,
			CountryRequirementModel model,
			CountryRequirement efCountryRequirement)
		{
			efCountryRequirement.SetProperties(
				id,
				model.CountryId,
				model.Details);
		}

		public virtual POCOCountryRequirement CountryRequirementMapEFToPOCO(
			CountryRequirement efCountryRequirement)
		{
			if (efCountryRequirement == null)
			{
				return null;
			}

			return new POCOCountryRequirement(efCountryRequirement.CountryId, efCountryRequirement.Details, efCountryRequirement.Id);
		}

		public virtual void DestinationMapModelToEF(
			int id,
			DestinationModel model,
			Destination efDestination)
		{
			efDestination.SetProperties(
				id,
				model.CountryId,
				model.Name,
				model.Order);
		}

		public virtual POCODestination DestinationMapEFToPOCO(
			Destination efDestination)
		{
			if (efDestination == null)
			{
				return null;
			}

			return new POCODestination(efDestination.CountryId, efDestination.Id, efDestination.Name, efDestination.Order);
		}

		public virtual void EmployeeMapModelToEF(
			int id,
			EmployeeModel model,
			Employee efEmployee)
		{
			efEmployee.SetProperties(
				id,
				model.FirstName,
				model.IsSalesPerson,
				model.IsShipper,
				model.LastName);
		}

		public virtual POCOEmployee EmployeeMapEFToPOCO(
			Employee efEmployee)
		{
			if (efEmployee == null)
			{
				return null;
			}

			return new POCOEmployee(efEmployee.FirstName, efEmployee.Id, efEmployee.IsSalesPerson, efEmployee.IsShipper, efEmployee.LastName);
		}

		public virtual void HandlerMapModelToEF(
			int id,
			HandlerModel model,
			Handler efHandler)
		{
			efHandler.SetProperties(
				id,
				model.CountryId,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone);
		}

		public virtual POCOHandler HandlerMapEFToPOCO(
			Handler efHandler)
		{
			if (efHandler == null)
			{
				return null;
			}

			return new POCOHandler(efHandler.CountryId, efHandler.Email, efHandler.FirstName, efHandler.Id, efHandler.LastName, efHandler.Phone);
		}

		public virtual void HandlerPipelineStepMapModelToEF(
			int id,
			HandlerPipelineStepModel model,
			HandlerPipelineStep efHandlerPipelineStep)
		{
			efHandlerPipelineStep.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
		}

		public virtual POCOHandlerPipelineStep HandlerPipelineStepMapEFToPOCO(
			HandlerPipelineStep efHandlerPipelineStep)
		{
			if (efHandlerPipelineStep == null)
			{
				return null;
			}

			return new POCOHandlerPipelineStep(efHandlerPipelineStep.HandlerId, efHandlerPipelineStep.Id, efHandlerPipelineStep.PipelineStepId);
		}

		public virtual void OtherTransportMapModelToEF(
			int id,
			OtherTransportModel model,
			OtherTransport efOtherTransport)
		{
			efOtherTransport.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
		}

		public virtual POCOOtherTransport OtherTransportMapEFToPOCO(
			OtherTransport efOtherTransport)
		{
			if (efOtherTransport == null)
			{
				return null;
			}

			return new POCOOtherTransport(efOtherTransport.HandlerId, efOtherTransport.Id, efOtherTransport.PipelineStepId);
		}

		public virtual void PetMapModelToEF(
			int id,
			PetModel model,
			Pet efPet)
		{
			efPet.SetProperties(
				id,
				model.BreedId,
				model.ClientId,
				model.Name,
				model.Weight);
		}

		public virtual POCOPet PetMapEFToPOCO(
			Pet efPet)
		{
			if (efPet == null)
			{
				return null;
			}

			return new POCOPet(efPet.BreedId, efPet.ClientId, efPet.Id, efPet.Name, efPet.Weight);
		}

		public virtual void PipelineMapModelToEF(
			int id,
			PipelineModel model,
			Pipeline efPipeline)
		{
			efPipeline.SetProperties(
				id,
				model.PipelineStatusId,
				model.SaleId);
		}

		public virtual POCOPipeline PipelineMapEFToPOCO(
			Pipeline efPipeline)
		{
			if (efPipeline == null)
			{
				return null;
			}

			return new POCOPipeline(efPipeline.Id, efPipeline.PipelineStatusId, efPipeline.SaleId);
		}

		public virtual void PipelineStatusMapModelToEF(
			int id,
			PipelineStatusModel model,
			PipelineStatus efPipelineStatus)
		{
			efPipelineStatus.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOPipelineStatus PipelineStatusMapEFToPOCO(
			PipelineStatus efPipelineStatus)
		{
			if (efPipelineStatus == null)
			{
				return null;
			}

			return new POCOPipelineStatus(efPipelineStatus.Id, efPipelineStatus.Name);
		}

		public virtual void PipelineStepMapModelToEF(
			int id,
			PipelineStepModel model,
			PipelineStep efPipelineStep)
		{
			efPipelineStep.SetProperties(
				id,
				model.Name,
				model.PipelineStepStatusId,
				model.ShipperId);
		}

		public virtual POCOPipelineStep PipelineStepMapEFToPOCO(
			PipelineStep efPipelineStep)
		{
			if (efPipelineStep == null)
			{
				return null;
			}

			return new POCOPipelineStep(efPipelineStep.Id, efPipelineStep.Name, efPipelineStep.PipelineStepStatusId, efPipelineStep.ShipperId);
		}

		public virtual void PipelineStepDestinationMapModelToEF(
			int id,
			PipelineStepDestinationModel model,
			PipelineStepDestination efPipelineStepDestination)
		{
			efPipelineStepDestination.SetProperties(
				id,
				model.DestinationId,
				model.PipelineStepId);
		}

		public virtual POCOPipelineStepDestination PipelineStepDestinationMapEFToPOCO(
			PipelineStepDestination efPipelineStepDestination)
		{
			if (efPipelineStepDestination == null)
			{
				return null;
			}

			return new POCOPipelineStepDestination(efPipelineStepDestination.DestinationId, efPipelineStepDestination.Id, efPipelineStepDestination.PipelineStepId);
		}

		public virtual void PipelineStepNoteMapModelToEF(
			int id,
			PipelineStepNoteModel model,
			PipelineStepNote efPipelineStepNote)
		{
			efPipelineStepNote.SetProperties(
				id,
				model.EmployeeId,
				model.Note,
				model.PipelineStepId);
		}

		public virtual POCOPipelineStepNote PipelineStepNoteMapEFToPOCO(
			PipelineStepNote efPipelineStepNote)
		{
			if (efPipelineStepNote == null)
			{
				return null;
			}

			return new POCOPipelineStepNote(efPipelineStepNote.EmployeeId, efPipelineStepNote.Id, efPipelineStepNote.Note, efPipelineStepNote.PipelineStepId);
		}

		public virtual void PipelineStepStatusMapModelToEF(
			int id,
			PipelineStepStatusModel model,
			PipelineStepStatus efPipelineStepStatus)
		{
			efPipelineStepStatus.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOPipelineStepStatus PipelineStepStatusMapEFToPOCO(
			PipelineStepStatus efPipelineStepStatus)
		{
			if (efPipelineStepStatus == null)
			{
				return null;
			}

			return new POCOPipelineStepStatus(efPipelineStepStatus.Id, efPipelineStepStatus.Name);
		}

		public virtual void PipelineStepStepRequirementMapModelToEF(
			int id,
			PipelineStepStepRequirementModel model,
			PipelineStepStepRequirement efPipelineStepStepRequirement)
		{
			efPipelineStepStepRequirement.SetProperties(
				id,
				model.Details,
				model.PipelineStepId,
				model.RequirementMet);
		}

		public virtual POCOPipelineStepStepRequirement PipelineStepStepRequirementMapEFToPOCO(
			PipelineStepStepRequirement efPipelineStepStepRequirement)
		{
			if (efPipelineStepStepRequirement == null)
			{
				return null;
			}

			return new POCOPipelineStepStepRequirement(efPipelineStepStepRequirement.Details, efPipelineStepStepRequirement.Id, efPipelineStepStepRequirement.PipelineStepId, efPipelineStepStepRequirement.RequirementMet);
		}

		public virtual void SaleMapModelToEF(
			int id,
			SaleModel model,
			Sale efSale)
		{
			efSale.SetProperties(
				id,
				model.Amount,
				model.ClientId,
				model.Note,
				model.PetId,
				model.SaleDate,
				model.SalesPersonId);
		}

		public virtual POCOSale SaleMapEFToPOCO(
			Sale efSale)
		{
			if (efSale == null)
			{
				return null;
			}

			return new POCOSale(efSale.Amount, efSale.ClientId, efSale.Id, efSale.Note, efSale.PetId, efSale.SaleDate, efSale.SalesPersonId);
		}

		public virtual void SpeciesMapModelToEF(
			int id,
			SpeciesModel model,
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
    <Hash>7c8cafa555312ea6c6349ac9b0711626</Hash>
</Codenesium>*/