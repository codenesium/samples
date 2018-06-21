using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiResponse
        {
                public ApiResponse()
                {
                }

                public void Merge(ApiResponse from)
                {
                        from.Airlines.ForEach(x => this.AddAirline(x));
                        from.AirTransports.ForEach(x => this.AddAirTransport(x));
                        from.Breeds.ForEach(x => this.AddBreed(x));
                        from.Clients.ForEach(x => this.AddClient(x));
                        from.ClientCommunications.ForEach(x => this.AddClientCommunication(x));
                        from.Countries.ForEach(x => this.AddCountry(x));
                        from.CountryRequirements.ForEach(x => this.AddCountryRequirement(x));
                        from.Destinations.ForEach(x => this.AddDestination(x));
                        from.Employees.ForEach(x => this.AddEmployee(x));
                        from.Handlers.ForEach(x => this.AddHandler(x));
                        from.HandlerPipelineSteps.ForEach(x => this.AddHandlerPipelineStep(x));
                        from.OtherTransports.ForEach(x => this.AddOtherTransport(x));
                        from.Pets.ForEach(x => this.AddPet(x));
                        from.Pipelines.ForEach(x => this.AddPipeline(x));
                        from.PipelineStatus.ForEach(x => this.AddPipelineStatus(x));
                        from.PipelineSteps.ForEach(x => this.AddPipelineStep(x));
                        from.PipelineStepDestinations.ForEach(x => this.AddPipelineStepDestination(x));
                        from.PipelineStepNotes.ForEach(x => this.AddPipelineStepNote(x));
                        from.PipelineStepStatus.ForEach(x => this.AddPipelineStepStatus(x));
                        from.PipelineStepStepRequirements.ForEach(x => this.AddPipelineStepStepRequirement(x));
                        from.Sales.ForEach(x => this.AddSale(x));
                        from.Species.ForEach(x => this.AddSpecies(x));
                }

                public List<ApiAirlineResponseModel> Airlines { get; private set; } = new List<ApiAirlineResponseModel>();

                public List<ApiAirTransportResponseModel> AirTransports { get; private set; } = new List<ApiAirTransportResponseModel>();

                public List<ApiBreedResponseModel> Breeds { get; private set; } = new List<ApiBreedResponseModel>();

                public List<ApiClientResponseModel> Clients { get; private set; } = new List<ApiClientResponseModel>();

                public List<ApiClientCommunicationResponseModel> ClientCommunications { get; private set; } = new List<ApiClientCommunicationResponseModel>();

                public List<ApiCountryResponseModel> Countries { get; private set; } = new List<ApiCountryResponseModel>();

                public List<ApiCountryRequirementResponseModel> CountryRequirements { get; private set; } = new List<ApiCountryRequirementResponseModel>();

                public List<ApiDestinationResponseModel> Destinations { get; private set; } = new List<ApiDestinationResponseModel>();

                public List<ApiEmployeeResponseModel> Employees { get; private set; } = new List<ApiEmployeeResponseModel>();

                public List<ApiHandlerResponseModel> Handlers { get; private set; } = new List<ApiHandlerResponseModel>();

                public List<ApiHandlerPipelineStepResponseModel> HandlerPipelineSteps { get; private set; } = new List<ApiHandlerPipelineStepResponseModel>();

                public List<ApiOtherTransportResponseModel> OtherTransports { get; private set; } = new List<ApiOtherTransportResponseModel>();

                public List<ApiPetResponseModel> Pets { get; private set; } = new List<ApiPetResponseModel>();

                public List<ApiPipelineResponseModel> Pipelines { get; private set; } = new List<ApiPipelineResponseModel>();

                public List<ApiPipelineStatusResponseModel> PipelineStatus { get; private set; } = new List<ApiPipelineStatusResponseModel>();

                public List<ApiPipelineStepResponseModel> PipelineSteps { get; private set; } = new List<ApiPipelineStepResponseModel>();

                public List<ApiPipelineStepDestinationResponseModel> PipelineStepDestinations { get; private set; } = new List<ApiPipelineStepDestinationResponseModel>();

                public List<ApiPipelineStepNoteResponseModel> PipelineStepNotes { get; private set; } = new List<ApiPipelineStepNoteResponseModel>();

                public List<ApiPipelineStepStatusResponseModel> PipelineStepStatus { get; private set; } = new List<ApiPipelineStepStatusResponseModel>();

                public List<ApiPipelineStepStepRequirementResponseModel> PipelineStepStepRequirements { get; private set; } = new List<ApiPipelineStepStepRequirementResponseModel>();

                public List<ApiSaleResponseModel> Sales { get; private set; } = new List<ApiSaleResponseModel>();

                public List<ApiSpeciesResponseModel> Species { get; private set; } = new List<ApiSpeciesResponseModel>();

                [JsonIgnore]
                public bool ShouldSerializeAirlinesValue { get; private set; } = true;

                public bool ShouldSerializeAirlines()
                {
                        return this.ShouldSerializeAirlinesValue;
                }

                public void AddAirline(ApiAirlineResponseModel item)
                {
                        if (!this.Airlines.Any(x => x.Id == item.Id))
                        {
                                this.Airlines.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeAirTransportsValue { get; private set; } = true;

                public bool ShouldSerializeAirTransports()
                {
                        return this.ShouldSerializeAirTransportsValue;
                }

                public void AddAirTransport(ApiAirTransportResponseModel item)
                {
                        if (!this.AirTransports.Any(x => x.AirlineId == item.AirlineId))
                        {
                                this.AirTransports.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeBreedsValue { get; private set; } = true;

                public bool ShouldSerializeBreeds()
                {
                        return this.ShouldSerializeBreedsValue;
                }

                public void AddBreed(ApiBreedResponseModel item)
                {
                        if (!this.Breeds.Any(x => x.Id == item.Id))
                        {
                                this.Breeds.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeClientsValue { get; private set; } = true;

                public bool ShouldSerializeClients()
                {
                        return this.ShouldSerializeClientsValue;
                }

                public void AddClient(ApiClientResponseModel item)
                {
                        if (!this.Clients.Any(x => x.Id == item.Id))
                        {
                                this.Clients.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeClientCommunicationsValue { get; private set; } = true;

                public bool ShouldSerializeClientCommunications()
                {
                        return this.ShouldSerializeClientCommunicationsValue;
                }

                public void AddClientCommunication(ApiClientCommunicationResponseModel item)
                {
                        if (!this.ClientCommunications.Any(x => x.Id == item.Id))
                        {
                                this.ClientCommunications.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCountriesValue { get; private set; } = true;

                public bool ShouldSerializeCountries()
                {
                        return this.ShouldSerializeCountriesValue;
                }

                public void AddCountry(ApiCountryResponseModel item)
                {
                        if (!this.Countries.Any(x => x.Id == item.Id))
                        {
                                this.Countries.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCountryRequirementsValue { get; private set; } = true;

                public bool ShouldSerializeCountryRequirements()
                {
                        return this.ShouldSerializeCountryRequirementsValue;
                }

                public void AddCountryRequirement(ApiCountryRequirementResponseModel item)
                {
                        if (!this.CountryRequirements.Any(x => x.Id == item.Id))
                        {
                                this.CountryRequirements.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeDestinationsValue { get; private set; } = true;

                public bool ShouldSerializeDestinations()
                {
                        return this.ShouldSerializeDestinationsValue;
                }

                public void AddDestination(ApiDestinationResponseModel item)
                {
                        if (!this.Destinations.Any(x => x.Id == item.Id))
                        {
                                this.Destinations.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeEmployeesValue { get; private set; } = true;

                public bool ShouldSerializeEmployees()
                {
                        return this.ShouldSerializeEmployeesValue;
                }

                public void AddEmployee(ApiEmployeeResponseModel item)
                {
                        if (!this.Employees.Any(x => x.Id == item.Id))
                        {
                                this.Employees.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeHandlersValue { get; private set; } = true;

                public bool ShouldSerializeHandlers()
                {
                        return this.ShouldSerializeHandlersValue;
                }

                public void AddHandler(ApiHandlerResponseModel item)
                {
                        if (!this.Handlers.Any(x => x.Id == item.Id))
                        {
                                this.Handlers.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeHandlerPipelineStepsValue { get; private set; } = true;

                public bool ShouldSerializeHandlerPipelineSteps()
                {
                        return this.ShouldSerializeHandlerPipelineStepsValue;
                }

                public void AddHandlerPipelineStep(ApiHandlerPipelineStepResponseModel item)
                {
                        if (!this.HandlerPipelineSteps.Any(x => x.Id == item.Id))
                        {
                                this.HandlerPipelineSteps.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeOtherTransportsValue { get; private set; } = true;

                public bool ShouldSerializeOtherTransports()
                {
                        return this.ShouldSerializeOtherTransportsValue;
                }

                public void AddOtherTransport(ApiOtherTransportResponseModel item)
                {
                        if (!this.OtherTransports.Any(x => x.Id == item.Id))
                        {
                                this.OtherTransports.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePetsValue { get; private set; } = true;

                public bool ShouldSerializePets()
                {
                        return this.ShouldSerializePetsValue;
                }

                public void AddPet(ApiPetResponseModel item)
                {
                        if (!this.Pets.Any(x => x.Id == item.Id))
                        {
                                this.Pets.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePipelinesValue { get; private set; } = true;

                public bool ShouldSerializePipelines()
                {
                        return this.ShouldSerializePipelinesValue;
                }

                public void AddPipeline(ApiPipelineResponseModel item)
                {
                        if (!this.Pipelines.Any(x => x.Id == item.Id))
                        {
                                this.Pipelines.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStatusValue { get; private set; } = true;

                public bool ShouldSerializePipelineStatus()
                {
                        return this.ShouldSerializePipelineStatusValue;
                }

                public void AddPipelineStatus(ApiPipelineStatusResponseModel item)
                {
                        if (!this.PipelineStatus.Any(x => x.Id == item.Id))
                        {
                                this.PipelineStatus.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStepsValue { get; private set; } = true;

                public bool ShouldSerializePipelineSteps()
                {
                        return this.ShouldSerializePipelineStepsValue;
                }

                public void AddPipelineStep(ApiPipelineStepResponseModel item)
                {
                        if (!this.PipelineSteps.Any(x => x.Id == item.Id))
                        {
                                this.PipelineSteps.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStepDestinationsValue { get; private set; } = true;

                public bool ShouldSerializePipelineStepDestinations()
                {
                        return this.ShouldSerializePipelineStepDestinationsValue;
                }

                public void AddPipelineStepDestination(ApiPipelineStepDestinationResponseModel item)
                {
                        if (!this.PipelineStepDestinations.Any(x => x.Id == item.Id))
                        {
                                this.PipelineStepDestinations.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStepNotesValue { get; private set; } = true;

                public bool ShouldSerializePipelineStepNotes()
                {
                        return this.ShouldSerializePipelineStepNotesValue;
                }

                public void AddPipelineStepNote(ApiPipelineStepNoteResponseModel item)
                {
                        if (!this.PipelineStepNotes.Any(x => x.Id == item.Id))
                        {
                                this.PipelineStepNotes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStepStatusValue { get; private set; } = true;

                public bool ShouldSerializePipelineStepStatus()
                {
                        return this.ShouldSerializePipelineStepStatusValue;
                }

                public void AddPipelineStepStatus(ApiPipelineStepStatusResponseModel item)
                {
                        if (!this.PipelineStepStatus.Any(x => x.Id == item.Id))
                        {
                                this.PipelineStepStatus.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStepStepRequirementsValue { get; private set; } = true;

                public bool ShouldSerializePipelineStepStepRequirements()
                {
                        return this.ShouldSerializePipelineStepStepRequirementsValue;
                }

                public void AddPipelineStepStepRequirement(ApiPipelineStepStepRequirementResponseModel item)
                {
                        if (!this.PipelineStepStepRequirements.Any(x => x.Id == item.Id))
                        {
                                this.PipelineStepStepRequirements.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesValue { get; private set; } = true;

                public bool ShouldSerializeSales()
                {
                        return this.ShouldSerializeSalesValue;
                }

                public void AddSale(ApiSaleResponseModel item)
                {
                        if (!this.Sales.Any(x => x.Id == item.Id))
                        {
                                this.Sales.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSpeciesValue { get; private set; } = true;

                public bool ShouldSerializeSpecies()
                {
                        return this.ShouldSerializeSpeciesValue;
                }

                public void AddSpecies(ApiSpeciesResponseModel item)
                {
                        if (!this.Species.Any(x => x.Id == item.Id))
                        {
                                this.Species.Add(item);
                        }
                }

                public void DisableSerializationOfEmptyFields()
                {
                        if (this.Airlines.Count == 0)
                        {
                                this.ShouldSerializeAirlinesValue = false;
                        }

                        if (this.AirTransports.Count == 0)
                        {
                                this.ShouldSerializeAirTransportsValue = false;
                        }

                        if (this.Breeds.Count == 0)
                        {
                                this.ShouldSerializeBreedsValue = false;
                        }

                        if (this.Clients.Count == 0)
                        {
                                this.ShouldSerializeClientsValue = false;
                        }

                        if (this.ClientCommunications.Count == 0)
                        {
                                this.ShouldSerializeClientCommunicationsValue = false;
                        }

                        if (this.Countries.Count == 0)
                        {
                                this.ShouldSerializeCountriesValue = false;
                        }

                        if (this.CountryRequirements.Count == 0)
                        {
                                this.ShouldSerializeCountryRequirementsValue = false;
                        }

                        if (this.Destinations.Count == 0)
                        {
                                this.ShouldSerializeDestinationsValue = false;
                        }

                        if (this.Employees.Count == 0)
                        {
                                this.ShouldSerializeEmployeesValue = false;
                        }

                        if (this.Handlers.Count == 0)
                        {
                                this.ShouldSerializeHandlersValue = false;
                        }

                        if (this.HandlerPipelineSteps.Count == 0)
                        {
                                this.ShouldSerializeHandlerPipelineStepsValue = false;
                        }

                        if (this.OtherTransports.Count == 0)
                        {
                                this.ShouldSerializeOtherTransportsValue = false;
                        }

                        if (this.Pets.Count == 0)
                        {
                                this.ShouldSerializePetsValue = false;
                        }

                        if (this.Pipelines.Count == 0)
                        {
                                this.ShouldSerializePipelinesValue = false;
                        }

                        if (this.PipelineStatus.Count == 0)
                        {
                                this.ShouldSerializePipelineStatusValue = false;
                        }

                        if (this.PipelineSteps.Count == 0)
                        {
                                this.ShouldSerializePipelineStepsValue = false;
                        }

                        if (this.PipelineStepDestinations.Count == 0)
                        {
                                this.ShouldSerializePipelineStepDestinationsValue = false;
                        }

                        if (this.PipelineStepNotes.Count == 0)
                        {
                                this.ShouldSerializePipelineStepNotesValue = false;
                        }

                        if (this.PipelineStepStatus.Count == 0)
                        {
                                this.ShouldSerializePipelineStepStatusValue = false;
                        }

                        if (this.PipelineStepStepRequirements.Count == 0)
                        {
                                this.ShouldSerializePipelineStepStepRequirementsValue = false;
                        }

                        if (this.Sales.Count == 0)
                        {
                                this.ShouldSerializeSalesValue = false;
                        }

                        if (this.Species.Count == 0)
                        {
                                this.ShouldSerializeSpeciesValue = false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>6fbe65b1cf6848ad4f3f33e705d781e6</Hash>
</Codenesium>*/