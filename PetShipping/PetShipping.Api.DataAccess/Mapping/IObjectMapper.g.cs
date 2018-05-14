using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void AirlineMapModelToEF(
			int id,
			ApiAirlineModel model,
			Airline efAirline);

		POCOAirline AirlineMapEFToPOCO(
			Airline efAirline);

		void AirTransportMapModelToEF(
			int airlineId,
			ApiAirTransportModel model,
			AirTransport efAirTransport);

		POCOAirTransport AirTransportMapEFToPOCO(
			AirTransport efAirTransport);

		void BreedMapModelToEF(
			int id,
			ApiBreedModel model,
			Breed efBreed);

		POCOBreed BreedMapEFToPOCO(
			Breed efBreed);

		void ClientMapModelToEF(
			int id,
			ApiClientModel model,
			Client efClient);

		POCOClient ClientMapEFToPOCO(
			Client efClient);

		void ClientCommunicationMapModelToEF(
			int id,
			ApiClientCommunicationModel model,
			ClientCommunication efClientCommunication);

		POCOClientCommunication ClientCommunicationMapEFToPOCO(
			ClientCommunication efClientCommunication);

		void CountryMapModelToEF(
			int id,
			ApiCountryModel model,
			Country efCountry);

		POCOCountry CountryMapEFToPOCO(
			Country efCountry);

		void CountryRequirementMapModelToEF(
			int id,
			ApiCountryRequirementModel model,
			CountryRequirement efCountryRequirement);

		POCOCountryRequirement CountryRequirementMapEFToPOCO(
			CountryRequirement efCountryRequirement);

		void DestinationMapModelToEF(
			int id,
			ApiDestinationModel model,
			Destination efDestination);

		POCODestination DestinationMapEFToPOCO(
			Destination efDestination);

		void EmployeeMapModelToEF(
			int id,
			ApiEmployeeModel model,
			Employee efEmployee);

		POCOEmployee EmployeeMapEFToPOCO(
			Employee efEmployee);

		void HandlerMapModelToEF(
			int id,
			ApiHandlerModel model,
			Handler efHandler);

		POCOHandler HandlerMapEFToPOCO(
			Handler efHandler);

		void HandlerPipelineStepMapModelToEF(
			int id,
			ApiHandlerPipelineStepModel model,
			HandlerPipelineStep efHandlerPipelineStep);

		POCOHandlerPipelineStep HandlerPipelineStepMapEFToPOCO(
			HandlerPipelineStep efHandlerPipelineStep);

		void OtherTransportMapModelToEF(
			int id,
			ApiOtherTransportModel model,
			OtherTransport efOtherTransport);

		POCOOtherTransport OtherTransportMapEFToPOCO(
			OtherTransport efOtherTransport);

		void PetMapModelToEF(
			int id,
			ApiPetModel model,
			Pet efPet);

		POCOPet PetMapEFToPOCO(
			Pet efPet);

		void PipelineMapModelToEF(
			int id,
			ApiPipelineModel model,
			Pipeline efPipeline);

		POCOPipeline PipelineMapEFToPOCO(
			Pipeline efPipeline);

		void PipelineStatusMapModelToEF(
			int id,
			ApiPipelineStatusModel model,
			PipelineStatus efPipelineStatus);

		POCOPipelineStatus PipelineStatusMapEFToPOCO(
			PipelineStatus efPipelineStatus);

		void PipelineStepMapModelToEF(
			int id,
			ApiPipelineStepModel model,
			PipelineStep efPipelineStep);

		POCOPipelineStep PipelineStepMapEFToPOCO(
			PipelineStep efPipelineStep);

		void PipelineStepDestinationMapModelToEF(
			int id,
			ApiPipelineStepDestinationModel model,
			PipelineStepDestination efPipelineStepDestination);

		POCOPipelineStepDestination PipelineStepDestinationMapEFToPOCO(
			PipelineStepDestination efPipelineStepDestination);

		void PipelineStepNoteMapModelToEF(
			int id,
			ApiPipelineStepNoteModel model,
			PipelineStepNote efPipelineStepNote);

		POCOPipelineStepNote PipelineStepNoteMapEFToPOCO(
			PipelineStepNote efPipelineStepNote);

		void PipelineStepStatusMapModelToEF(
			int id,
			ApiPipelineStepStatusModel model,
			PipelineStepStatus efPipelineStepStatus);

		POCOPipelineStepStatus PipelineStepStatusMapEFToPOCO(
			PipelineStepStatus efPipelineStepStatus);

		void PipelineStepStepRequirementMapModelToEF(
			int id,
			ApiPipelineStepStepRequirementModel model,
			PipelineStepStepRequirement efPipelineStepStepRequirement);

		POCOPipelineStepStepRequirement PipelineStepStepRequirementMapEFToPOCO(
			PipelineStepStepRequirement efPipelineStepStepRequirement);

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
    <Hash>4ce89326d81e9a26087985b242c9fe4e</Hash>
</Codenesium>*/