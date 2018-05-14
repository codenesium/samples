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
			Airline efAirline);

		POCOAirline AirlineMapEFToPOCO(
			Airline efAirline);

		void AirTransportMapModelToEF(
			int airlineId,
			AirTransportModel model,
			AirTransport efAirTransport);

		POCOAirTransport AirTransportMapEFToPOCO(
			AirTransport efAirTransport);

		void BreedMapModelToEF(
			int id,
			BreedModel model,
			Breed efBreed);

		POCOBreed BreedMapEFToPOCO(
			Breed efBreed);

		void ClientMapModelToEF(
			int id,
			ClientModel model,
			Client efClient);

		POCOClient ClientMapEFToPOCO(
			Client efClient);

		void ClientCommunicationMapModelToEF(
			int id,
			ClientCommunicationModel model,
			ClientCommunication efClientCommunication);

		POCOClientCommunication ClientCommunicationMapEFToPOCO(
			ClientCommunication efClientCommunication);

		void CountryMapModelToEF(
			int id,
			CountryModel model,
			Country efCountry);

		POCOCountry CountryMapEFToPOCO(
			Country efCountry);

		void CountryRequirementMapModelToEF(
			int id,
			CountryRequirementModel model,
			CountryRequirement efCountryRequirement);

		POCOCountryRequirement CountryRequirementMapEFToPOCO(
			CountryRequirement efCountryRequirement);

		void DestinationMapModelToEF(
			int id,
			DestinationModel model,
			Destination efDestination);

		POCODestination DestinationMapEFToPOCO(
			Destination efDestination);

		void EmployeeMapModelToEF(
			int id,
			EmployeeModel model,
			Employee efEmployee);

		POCOEmployee EmployeeMapEFToPOCO(
			Employee efEmployee);

		void HandlerMapModelToEF(
			int id,
			HandlerModel model,
			Handler efHandler);

		POCOHandler HandlerMapEFToPOCO(
			Handler efHandler);

		void HandlerPipelineStepMapModelToEF(
			int id,
			HandlerPipelineStepModel model,
			HandlerPipelineStep efHandlerPipelineStep);

		POCOHandlerPipelineStep HandlerPipelineStepMapEFToPOCO(
			HandlerPipelineStep efHandlerPipelineStep);

		void OtherTransportMapModelToEF(
			int id,
			OtherTransportModel model,
			OtherTransport efOtherTransport);

		POCOOtherTransport OtherTransportMapEFToPOCO(
			OtherTransport efOtherTransport);

		void PetMapModelToEF(
			int id,
			PetModel model,
			Pet efPet);

		POCOPet PetMapEFToPOCO(
			Pet efPet);

		void PipelineMapModelToEF(
			int id,
			PipelineModel model,
			Pipeline efPipeline);

		POCOPipeline PipelineMapEFToPOCO(
			Pipeline efPipeline);

		void PipelineStatusMapModelToEF(
			int id,
			PipelineStatusModel model,
			PipelineStatus efPipelineStatus);

		POCOPipelineStatus PipelineStatusMapEFToPOCO(
			PipelineStatus efPipelineStatus);

		void PipelineStepMapModelToEF(
			int id,
			PipelineStepModel model,
			PipelineStep efPipelineStep);

		POCOPipelineStep PipelineStepMapEFToPOCO(
			PipelineStep efPipelineStep);

		void PipelineStepDestinationMapModelToEF(
			int id,
			PipelineStepDestinationModel model,
			PipelineStepDestination efPipelineStepDestination);

		POCOPipelineStepDestination PipelineStepDestinationMapEFToPOCO(
			PipelineStepDestination efPipelineStepDestination);

		void PipelineStepNoteMapModelToEF(
			int id,
			PipelineStepNoteModel model,
			PipelineStepNote efPipelineStepNote);

		POCOPipelineStepNote PipelineStepNoteMapEFToPOCO(
			PipelineStepNote efPipelineStepNote);

		void PipelineStepStatusMapModelToEF(
			int id,
			PipelineStepStatusModel model,
			PipelineStepStatus efPipelineStepStatus);

		POCOPipelineStepStatus PipelineStepStatusMapEFToPOCO(
			PipelineStepStatus efPipelineStepStatus);

		void PipelineStepStepRequirementMapModelToEF(
			int id,
			PipelineStepStepRequirementModel model,
			PipelineStepStepRequirement efPipelineStepStepRequirement);

		POCOPipelineStepStepRequirement PipelineStepStepRequirementMapEFToPOCO(
			PipelineStepStepRequirement efPipelineStepStepRequirement);

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
    <Hash>2ca5730485c58f99c4f9a02deccfe956</Hash>
</Codenesium>*/