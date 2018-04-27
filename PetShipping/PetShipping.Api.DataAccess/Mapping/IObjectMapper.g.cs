using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void AirlineMapModelToEF(
			int id,
			AirlineModel model,
			EFAirline efAirline);

		void AirlineMapEFToPOCO(
			EFAirline efAirline,
			ApiResponse response);

		void AirTransportMapModelToEF(
			int airlineId,
			AirTransportModel model,
			EFAirTransport efAirTransport);

		void AirTransportMapEFToPOCO(
			EFAirTransport efAirTransport,
			ApiResponse response);

		void BreedMapModelToEF(
			int id,
			BreedModel model,
			EFBreed efBreed);

		void BreedMapEFToPOCO(
			EFBreed efBreed,
			ApiResponse response);

		void ClientMapModelToEF(
			int id,
			ClientModel model,
			EFClient efClient);

		void ClientMapEFToPOCO(
			EFClient efClient,
			ApiResponse response);

		void ClientCommunicationMapModelToEF(
			int id,
			ClientCommunicationModel model,
			EFClientCommunication efClientCommunication);

		void ClientCommunicationMapEFToPOCO(
			EFClientCommunication efClientCommunication,
			ApiResponse response);

		void CountryMapModelToEF(
			int id,
			CountryModel model,
			EFCountry efCountry);

		void CountryMapEFToPOCO(
			EFCountry efCountry,
			ApiResponse response);

		void CountryRequirementMapModelToEF(
			int id,
			CountryRequirementModel model,
			EFCountryRequirement efCountryRequirement);

		void CountryRequirementMapEFToPOCO(
			EFCountryRequirement efCountryRequirement,
			ApiResponse response);

		void DestinationMapModelToEF(
			int id,
			DestinationModel model,
			EFDestination efDestination);

		void DestinationMapEFToPOCO(
			EFDestination efDestination,
			ApiResponse response);

		void EmployeeMapModelToEF(
			int id,
			EmployeeModel model,
			EFEmployee efEmployee);

		void EmployeeMapEFToPOCO(
			EFEmployee efEmployee,
			ApiResponse response);

		void HandlerMapModelToEF(
			int id,
			HandlerModel model,
			EFHandler efHandler);

		void HandlerMapEFToPOCO(
			EFHandler efHandler,
			ApiResponse response);

		void HandlerPipelineStepMapModelToEF(
			int id,
			HandlerPipelineStepModel model,
			EFHandlerPipelineStep efHandlerPipelineStep);

		void HandlerPipelineStepMapEFToPOCO(
			EFHandlerPipelineStep efHandlerPipelineStep,
			ApiResponse response);

		void OtherTransportMapModelToEF(
			int id,
			OtherTransportModel model,
			EFOtherTransport efOtherTransport);

		void OtherTransportMapEFToPOCO(
			EFOtherTransport efOtherTransport,
			ApiResponse response);

		void PetMapModelToEF(
			int id,
			PetModel model,
			EFPet efPet);

		void PetMapEFToPOCO(
			EFPet efPet,
			ApiResponse response);

		void PipelineMapModelToEF(
			int id,
			PipelineModel model,
			EFPipeline efPipeline);

		void PipelineMapEFToPOCO(
			EFPipeline efPipeline,
			ApiResponse response);

		void PipelineStatusMapModelToEF(
			int id,
			PipelineStatusModel model,
			EFPipelineStatus efPipelineStatus);

		void PipelineStatusMapEFToPOCO(
			EFPipelineStatus efPipelineStatus,
			ApiResponse response);

		void PipelineStepMapModelToEF(
			int id,
			PipelineStepModel model,
			EFPipelineStep efPipelineStep);

		void PipelineStepMapEFToPOCO(
			EFPipelineStep efPipelineStep,
			ApiResponse response);

		void PipelineStepDestinationMapModelToEF(
			int id,
			PipelineStepDestinationModel model,
			EFPipelineStepDestination efPipelineStepDestination);

		void PipelineStepDestinationMapEFToPOCO(
			EFPipelineStepDestination efPipelineStepDestination,
			ApiResponse response);

		void PipelineStepNoteMapModelToEF(
			int id,
			PipelineStepNoteModel model,
			EFPipelineStepNote efPipelineStepNote);

		void PipelineStepNoteMapEFToPOCO(
			EFPipelineStepNote efPipelineStepNote,
			ApiResponse response);

		void PipelineStepStatusMapModelToEF(
			int id,
			PipelineStepStatusModel model,
			EFPipelineStepStatus efPipelineStepStatus);

		void PipelineStepStatusMapEFToPOCO(
			EFPipelineStepStatus efPipelineStepStatus,
			ApiResponse response);

		void PipelineStepStepRequirementMapModelToEF(
			int id,
			PipelineStepStepRequirementModel model,
			EFPipelineStepStepRequirement efPipelineStepStepRequirement);

		void PipelineStepStepRequirementMapEFToPOCO(
			EFPipelineStepStepRequirement efPipelineStepStepRequirement,
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
    <Hash>3c8c1cccd2c1470f9a882b8cf979a510</Hash>
</Codenesium>*/