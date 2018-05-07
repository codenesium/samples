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

		POCOAirline AirlineMapEFToPOCO(
			EFAirline efAirline);

		void AirTransportMapModelToEF(
			int airlineId,
			AirTransportModel model,
			EFAirTransport efAirTransport);

		POCOAirTransport AirTransportMapEFToPOCO(
			EFAirTransport efAirTransport);

		void BreedMapModelToEF(
			int id,
			BreedModel model,
			EFBreed efBreed);

		POCOBreed BreedMapEFToPOCO(
			EFBreed efBreed);

		void ClientMapModelToEF(
			int id,
			ClientModel model,
			EFClient efClient);

		POCOClient ClientMapEFToPOCO(
			EFClient efClient);

		void ClientCommunicationMapModelToEF(
			int id,
			ClientCommunicationModel model,
			EFClientCommunication efClientCommunication);

		POCOClientCommunication ClientCommunicationMapEFToPOCO(
			EFClientCommunication efClientCommunication);

		void CountryMapModelToEF(
			int id,
			CountryModel model,
			EFCountry efCountry);

		POCOCountry CountryMapEFToPOCO(
			EFCountry efCountry);

		void CountryRequirementMapModelToEF(
			int id,
			CountryRequirementModel model,
			EFCountryRequirement efCountryRequirement);

		POCOCountryRequirement CountryRequirementMapEFToPOCO(
			EFCountryRequirement efCountryRequirement);

		void DestinationMapModelToEF(
			int id,
			DestinationModel model,
			EFDestination efDestination);

		POCODestination DestinationMapEFToPOCO(
			EFDestination efDestination);

		void EmployeeMapModelToEF(
			int id,
			EmployeeModel model,
			EFEmployee efEmployee);

		POCOEmployee EmployeeMapEFToPOCO(
			EFEmployee efEmployee);

		void HandlerMapModelToEF(
			int id,
			HandlerModel model,
			EFHandler efHandler);

		POCOHandler HandlerMapEFToPOCO(
			EFHandler efHandler);

		void HandlerPipelineStepMapModelToEF(
			int id,
			HandlerPipelineStepModel model,
			EFHandlerPipelineStep efHandlerPipelineStep);

		POCOHandlerPipelineStep HandlerPipelineStepMapEFToPOCO(
			EFHandlerPipelineStep efHandlerPipelineStep);

		void OtherTransportMapModelToEF(
			int id,
			OtherTransportModel model,
			EFOtherTransport efOtherTransport);

		POCOOtherTransport OtherTransportMapEFToPOCO(
			EFOtherTransport efOtherTransport);

		void PetMapModelToEF(
			int id,
			PetModel model,
			EFPet efPet);

		POCOPet PetMapEFToPOCO(
			EFPet efPet);

		void PipelineMapModelToEF(
			int id,
			PipelineModel model,
			EFPipeline efPipeline);

		POCOPipeline PipelineMapEFToPOCO(
			EFPipeline efPipeline);

		void PipelineStatusMapModelToEF(
			int id,
			PipelineStatusModel model,
			EFPipelineStatus efPipelineStatus);

		POCOPipelineStatus PipelineStatusMapEFToPOCO(
			EFPipelineStatus efPipelineStatus);

		void PipelineStepMapModelToEF(
			int id,
			PipelineStepModel model,
			EFPipelineStep efPipelineStep);

		POCOPipelineStep PipelineStepMapEFToPOCO(
			EFPipelineStep efPipelineStep);

		void PipelineStepDestinationMapModelToEF(
			int id,
			PipelineStepDestinationModel model,
			EFPipelineStepDestination efPipelineStepDestination);

		POCOPipelineStepDestination PipelineStepDestinationMapEFToPOCO(
			EFPipelineStepDestination efPipelineStepDestination);

		void PipelineStepNoteMapModelToEF(
			int id,
			PipelineStepNoteModel model,
			EFPipelineStepNote efPipelineStepNote);

		POCOPipelineStepNote PipelineStepNoteMapEFToPOCO(
			EFPipelineStepNote efPipelineStepNote);

		void PipelineStepStatusMapModelToEF(
			int id,
			PipelineStepStatusModel model,
			EFPipelineStepStatus efPipelineStepStatus);

		POCOPipelineStepStatus PipelineStepStatusMapEFToPOCO(
			EFPipelineStepStatus efPipelineStepStatus);

		void PipelineStepStepRequirementMapModelToEF(
			int id,
			PipelineStepStepRequirementModel model,
			EFPipelineStepStepRequirement efPipelineStepStepRequirement);

		POCOPipelineStepStepRequirement PipelineStepStepRequirementMapEFToPOCO(
			EFPipelineStepStepRequirement efPipelineStepStepRequirement);

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
    <Hash>8ce178fe63dbfd225b2c0221e0917bee</Hash>
</Codenesium>*/