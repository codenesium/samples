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
			EFAirline efAirline)
		{
			efAirline.SetProperties(
				id,
				model.Name);
		}

		public virtual void AirlineMapEFToPOCO(
			EFAirline efAirline,
			ApiResponse response)
		{
			if (efAirline == null)
			{
				return;
			}

			response.AddAirline(new POCOAirline(efAirline.Id, efAirline.Name));
		}

		public virtual void AirTransportMapModelToEF(
			int airlineId,
			AirTransportModel model,
			EFAirTransport efAirTransport)
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

		public virtual void AirTransportMapEFToPOCO(
			EFAirTransport efAirTransport,
			ApiResponse response)
		{
			if (efAirTransport == null)
			{
				return;
			}

			response.AddAirTransport(new POCOAirTransport(efAirTransport.AirlineId, efAirTransport.FlightNumber, efAirTransport.HandlerId, efAirTransport.Id, efAirTransport.LandDate, efAirTransport.PipelineStepId, efAirTransport.TakeoffDate));

			this.HandlerMapEFToPOCO(efAirTransport.Handler, response);
		}

		public virtual void BreedMapModelToEF(
			int id,
			BreedModel model,
			EFBreed efBreed)
		{
			efBreed.SetProperties(
				id,
				model.Name,
				model.SpeciesId);
		}

		public virtual void BreedMapEFToPOCO(
			EFBreed efBreed,
			ApiResponse response)
		{
			if (efBreed == null)
			{
				return;
			}

			response.AddBreed(new POCOBreed(efBreed.Id, efBreed.Name, efBreed.SpeciesId));

			this.SpeciesMapEFToPOCO(efBreed.Species, response);
		}

		public virtual void ClientMapModelToEF(
			int id,
			ClientModel model,
			EFClient efClient)
		{
			efClient.SetProperties(
				id,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Notes,
				model.Phone);
		}

		public virtual void ClientMapEFToPOCO(
			EFClient efClient,
			ApiResponse response)
		{
			if (efClient == null)
			{
				return;
			}

			response.AddClient(new POCOClient(efClient.Email, efClient.FirstName, efClient.Id, efClient.LastName, efClient.Notes, efClient.Phone));
		}

		public virtual void ClientCommunicationMapModelToEF(
			int id,
			ClientCommunicationModel model,
			EFClientCommunication efClientCommunication)
		{
			efClientCommunication.SetProperties(
				id,
				model.ClientId,
				model.DateCreated,
				model.EmployeeId,
				model.Notes);
		}

		public virtual void ClientCommunicationMapEFToPOCO(
			EFClientCommunication efClientCommunication,
			ApiResponse response)
		{
			if (efClientCommunication == null)
			{
				return;
			}

			response.AddClientCommunication(new POCOClientCommunication(efClientCommunication.ClientId, efClientCommunication.DateCreated, efClientCommunication.EmployeeId, efClientCommunication.Id, efClientCommunication.Notes));

			this.ClientMapEFToPOCO(efClientCommunication.Client, response);

			this.EmployeeMapEFToPOCO(efClientCommunication.Employee, response);
		}

		public virtual void CountryMapModelToEF(
			int id,
			CountryModel model,
			EFCountry efCountry)
		{
			efCountry.SetProperties(
				id,
				model.Name);
		}

		public virtual void CountryMapEFToPOCO(
			EFCountry efCountry,
			ApiResponse response)
		{
			if (efCountry == null)
			{
				return;
			}

			response.AddCountry(new POCOCountry(efCountry.Id, efCountry.Name));
		}

		public virtual void CountryRequirementMapModelToEF(
			int id,
			CountryRequirementModel model,
			EFCountryRequirement efCountryRequirement)
		{
			efCountryRequirement.SetProperties(
				id,
				model.CountryId,
				model.Details);
		}

		public virtual void CountryRequirementMapEFToPOCO(
			EFCountryRequirement efCountryRequirement,
			ApiResponse response)
		{
			if (efCountryRequirement == null)
			{
				return;
			}

			response.AddCountryRequirement(new POCOCountryRequirement(efCountryRequirement.CountryId, efCountryRequirement.Details, efCountryRequirement.Id));

			this.CountryMapEFToPOCO(efCountryRequirement.Country, response);
		}

		public virtual void DestinationMapModelToEF(
			int id,
			DestinationModel model,
			EFDestination efDestination)
		{
			efDestination.SetProperties(
				id,
				model.CountryId,
				model.Name,
				model.Order);
		}

		public virtual void DestinationMapEFToPOCO(
			EFDestination efDestination,
			ApiResponse response)
		{
			if (efDestination == null)
			{
				return;
			}

			response.AddDestination(new POCODestination(efDestination.CountryId, efDestination.Id, efDestination.Name, efDestination.Order));

			this.CountryMapEFToPOCO(efDestination.Country, response);
		}

		public virtual void EmployeeMapModelToEF(
			int id,
			EmployeeModel model,
			EFEmployee efEmployee)
		{
			efEmployee.SetProperties(
				id,
				model.FirstName,
				model.IsSalesPerson,
				model.IsShipper,
				model.LastName);
		}

		public virtual void EmployeeMapEFToPOCO(
			EFEmployee efEmployee,
			ApiResponse response)
		{
			if (efEmployee == null)
			{
				return;
			}

			response.AddEmployee(new POCOEmployee(efEmployee.FirstName, efEmployee.Id, efEmployee.IsSalesPerson, efEmployee.IsShipper, efEmployee.LastName));
		}

		public virtual void HandlerMapModelToEF(
			int id,
			HandlerModel model,
			EFHandler efHandler)
		{
			efHandler.SetProperties(
				id,
				model.CountryId,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone);
		}

		public virtual void HandlerMapEFToPOCO(
			EFHandler efHandler,
			ApiResponse response)
		{
			if (efHandler == null)
			{
				return;
			}

			response.AddHandler(new POCOHandler(efHandler.CountryId, efHandler.Email, efHandler.FirstName, efHandler.Id, efHandler.LastName, efHandler.Phone));
		}

		public virtual void HandlerPipelineStepMapModelToEF(
			int id,
			HandlerPipelineStepModel model,
			EFHandlerPipelineStep efHandlerPipelineStep)
		{
			efHandlerPipelineStep.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
		}

		public virtual void HandlerPipelineStepMapEFToPOCO(
			EFHandlerPipelineStep efHandlerPipelineStep,
			ApiResponse response)
		{
			if (efHandlerPipelineStep == null)
			{
				return;
			}

			response.AddHandlerPipelineStep(new POCOHandlerPipelineStep(efHandlerPipelineStep.HandlerId, efHandlerPipelineStep.Id, efHandlerPipelineStep.PipelineStepId));

			this.HandlerMapEFToPOCO(efHandlerPipelineStep.Handler, response);

			this.PipelineStepMapEFToPOCO(efHandlerPipelineStep.PipelineStep, response);
		}

		public virtual void OtherTransportMapModelToEF(
			int id,
			OtherTransportModel model,
			EFOtherTransport efOtherTransport)
		{
			efOtherTransport.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
		}

		public virtual void OtherTransportMapEFToPOCO(
			EFOtherTransport efOtherTransport,
			ApiResponse response)
		{
			if (efOtherTransport == null)
			{
				return;
			}

			response.AddOtherTransport(new POCOOtherTransport(efOtherTransport.HandlerId, efOtherTransport.Id, efOtherTransport.PipelineStepId));

			this.HandlerMapEFToPOCO(efOtherTransport.Handler, response);

			this.PipelineStepMapEFToPOCO(efOtherTransport.PipelineStep, response);
		}

		public virtual void PetMapModelToEF(
			int id,
			PetModel model,
			EFPet efPet)
		{
			efPet.SetProperties(
				id,
				model.BreedId,
				model.ClientId,
				model.Name,
				model.Weight);
		}

		public virtual void PetMapEFToPOCO(
			EFPet efPet,
			ApiResponse response)
		{
			if (efPet == null)
			{
				return;
			}

			response.AddPet(new POCOPet(efPet.BreedId, efPet.ClientId, efPet.Id, efPet.Name, efPet.Weight));

			this.BreedMapEFToPOCO(efPet.Breed, response);

			this.ClientMapEFToPOCO(efPet.Client, response);
		}

		public virtual void PipelineMapModelToEF(
			int id,
			PipelineModel model,
			EFPipeline efPipeline)
		{
			efPipeline.SetProperties(
				id,
				model.PipelineStatusId,
				model.SaleId);
		}

		public virtual void PipelineMapEFToPOCO(
			EFPipeline efPipeline,
			ApiResponse response)
		{
			if (efPipeline == null)
			{
				return;
			}

			response.AddPipeline(new POCOPipeline(efPipeline.Id, efPipeline.PipelineStatusId, efPipeline.SaleId));

			this.PipelineStatusMapEFToPOCO(efPipeline.PipelineStatus, response);
		}

		public virtual void PipelineStatusMapModelToEF(
			int id,
			PipelineStatusModel model,
			EFPipelineStatus efPipelineStatus)
		{
			efPipelineStatus.SetProperties(
				id,
				model.Name);
		}

		public virtual void PipelineStatusMapEFToPOCO(
			EFPipelineStatus efPipelineStatus,
			ApiResponse response)
		{
			if (efPipelineStatus == null)
			{
				return;
			}

			response.AddPipelineStatus(new POCOPipelineStatus(efPipelineStatus.Id, efPipelineStatus.Name));
		}

		public virtual void PipelineStepMapModelToEF(
			int id,
			PipelineStepModel model,
			EFPipelineStep efPipelineStep)
		{
			efPipelineStep.SetProperties(
				id,
				model.Name,
				model.PipelineStepStatusId,
				model.ShipperId);
		}

		public virtual void PipelineStepMapEFToPOCO(
			EFPipelineStep efPipelineStep,
			ApiResponse response)
		{
			if (efPipelineStep == null)
			{
				return;
			}

			response.AddPipelineStep(new POCOPipelineStep(efPipelineStep.Id, efPipelineStep.Name, efPipelineStep.PipelineStepStatusId, efPipelineStep.ShipperId));

			this.PipelineStepStatusMapEFToPOCO(efPipelineStep.PipelineStepStatus, response);

			this.EmployeeMapEFToPOCO(efPipelineStep.Employee, response);
		}

		public virtual void PipelineStepDestinationMapModelToEF(
			int id,
			PipelineStepDestinationModel model,
			EFPipelineStepDestination efPipelineStepDestination)
		{
			efPipelineStepDestination.SetProperties(
				id,
				model.DestinationId,
				model.PipelineStepId);
		}

		public virtual void PipelineStepDestinationMapEFToPOCO(
			EFPipelineStepDestination efPipelineStepDestination,
			ApiResponse response)
		{
			if (efPipelineStepDestination == null)
			{
				return;
			}

			response.AddPipelineStepDestination(new POCOPipelineStepDestination(efPipelineStepDestination.DestinationId, efPipelineStepDestination.Id, efPipelineStepDestination.PipelineStepId));

			this.DestinationMapEFToPOCO(efPipelineStepDestination.Destination, response);

			this.PipelineStepMapEFToPOCO(efPipelineStepDestination.PipelineStep, response);
		}

		public virtual void PipelineStepNoteMapModelToEF(
			int id,
			PipelineStepNoteModel model,
			EFPipelineStepNote efPipelineStepNote)
		{
			efPipelineStepNote.SetProperties(
				id,
				model.EmployeeId,
				model.Note,
				model.PipelineStepId);
		}

		public virtual void PipelineStepNoteMapEFToPOCO(
			EFPipelineStepNote efPipelineStepNote,
			ApiResponse response)
		{
			if (efPipelineStepNote == null)
			{
				return;
			}

			response.AddPipelineStepNote(new POCOPipelineStepNote(efPipelineStepNote.EmployeeId, efPipelineStepNote.Id, efPipelineStepNote.Note, efPipelineStepNote.PipelineStepId));

			this.EmployeeMapEFToPOCO(efPipelineStepNote.Employee, response);

			this.PipelineStepMapEFToPOCO(efPipelineStepNote.PipelineStep, response);
		}

		public virtual void PipelineStepStatusMapModelToEF(
			int id,
			PipelineStepStatusModel model,
			EFPipelineStepStatus efPipelineStepStatus)
		{
			efPipelineStepStatus.SetProperties(
				id,
				model.Name);
		}

		public virtual void PipelineStepStatusMapEFToPOCO(
			EFPipelineStepStatus efPipelineStepStatus,
			ApiResponse response)
		{
			if (efPipelineStepStatus == null)
			{
				return;
			}

			response.AddPipelineStepStatus(new POCOPipelineStepStatus(efPipelineStepStatus.Id, efPipelineStepStatus.Name));
		}

		public virtual void PipelineStepStepRequirementMapModelToEF(
			int id,
			PipelineStepStepRequirementModel model,
			EFPipelineStepStepRequirement efPipelineStepStepRequirement)
		{
			efPipelineStepStepRequirement.SetProperties(
				id,
				model.Details,
				model.PipelineStepId,
				model.RequirementMet);
		}

		public virtual void PipelineStepStepRequirementMapEFToPOCO(
			EFPipelineStepStepRequirement efPipelineStepStepRequirement,
			ApiResponse response)
		{
			if (efPipelineStepStepRequirement == null)
			{
				return;
			}

			response.AddPipelineStepStepRequirement(new POCOPipelineStepStepRequirement(efPipelineStepStepRequirement.Details, efPipelineStepStepRequirement.Id, efPipelineStepStepRequirement.PipelineStepId, efPipelineStepStepRequirement.RequirementMet));

			this.PipelineStepMapEFToPOCO(efPipelineStepStepRequirement.PipelineStep, response);
		}

		public virtual void SaleMapModelToEF(
			int id,
			SaleModel model,
			EFSale efSale)
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

		public virtual void SaleMapEFToPOCO(
			EFSale efSale,
			ApiResponse response)
		{
			if (efSale == null)
			{
				return;
			}

			response.AddSale(new POCOSale(efSale.Amount, efSale.ClientId, efSale.Id, efSale.Note, efSale.PetId, efSale.SaleDate, efSale.SalesPersonId));

			this.ClientMapEFToPOCO(efSale.Client, response);

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
    <Hash>3c2a8837abaeb0056da71ca938873ae1</Hash>
</Codenesium>*/