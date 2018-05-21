using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PetShippingNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		[JsonProperty(PropertyName = "Value")]
		public T Value { get; set; }

		[JsonProperty(PropertyName = "Object")]
		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class ApiResponse
	{
		public ApiResponse()
		{}

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

		public List<POCOAirline> Airlines { get; private set; } = new List<POCOAirline>();

		public List<POCOAirTransport> AirTransports { get; private set; } = new List<POCOAirTransport>();

		public List<POCOBreed> Breeds { get; private set; } = new List<POCOBreed>();

		public List<POCOClient> Clients { get; private set; } = new List<POCOClient>();

		public List<POCOClientCommunication> ClientCommunications { get; private set; } = new List<POCOClientCommunication>();

		public List<POCOCountry> Countries { get; private set; } = new List<POCOCountry>();

		public List<POCOCountryRequirement> CountryRequirements { get; private set; } = new List<POCOCountryRequirement>();

		public List<POCODestination> Destinations { get; private set; } = new List<POCODestination>();

		public List<POCOEmployee> Employees { get; private set; } = new List<POCOEmployee>();

		public List<POCOHandler> Handlers { get; private set; } = new List<POCOHandler>();

		public List<POCOHandlerPipelineStep> HandlerPipelineSteps { get; private set; } = new List<POCOHandlerPipelineStep>();

		public List<POCOOtherTransport> OtherTransports { get; private set; } = new List<POCOOtherTransport>();

		public List<POCOPet> Pets { get; private set; } = new List<POCOPet>();

		public List<POCOPipeline> Pipelines { get; private set; } = new List<POCOPipeline>();

		public List<POCOPipelineStatus> PipelineStatus { get; private set; } = new List<POCOPipelineStatus>();

		public List<POCOPipelineStep> PipelineSteps { get; private set; } = new List<POCOPipelineStep>();

		public List<POCOPipelineStepDestination> PipelineStepDestinations { get; private set; } = new List<POCOPipelineStepDestination>();

		public List<POCOPipelineStepNote> PipelineStepNotes { get; private set; } = new List<POCOPipelineStepNote>();

		public List<POCOPipelineStepStatus> PipelineStepStatus { get; private set; } = new List<POCOPipelineStepStatus>();

		public List<POCOPipelineStepStepRequirement> PipelineStepStepRequirements { get; private set; } = new List<POCOPipelineStepStepRequirement>();

		public List<POCOSale> Sales { get; private set; } = new List<POCOSale>();

		public List<POCOSpecies> Species { get; private set; } = new List<POCOSpecies>();

		[JsonIgnore]
		public bool ShouldSerializeAirlinesValue { get; set; } = true;

		public bool ShouldSerializeAirlines()
		{
			return this.ShouldSerializeAirlinesValue;
		}

		public void AddAirline(POCOAirline item)
		{
			if (!this.Airlines.Any(x => x.Id == item.Id))
			{
				this.Airlines.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeAirTransportsValue { get; set; } = true;

		public bool ShouldSerializeAirTransports()
		{
			return this.ShouldSerializeAirTransportsValue;
		}

		public void AddAirTransport(POCOAirTransport item)
		{
			if (!this.AirTransports.Any(x => x.AirlineId == item.AirlineId))
			{
				this.AirTransports.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeBreedsValue { get; set; } = true;

		public bool ShouldSerializeBreeds()
		{
			return this.ShouldSerializeBreedsValue;
		}

		public void AddBreed(POCOBreed item)
		{
			if (!this.Breeds.Any(x => x.Id == item.Id))
			{
				this.Breeds.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeClientsValue { get; set; } = true;

		public bool ShouldSerializeClients()
		{
			return this.ShouldSerializeClientsValue;
		}

		public void AddClient(POCOClient item)
		{
			if (!this.Clients.Any(x => x.Id == item.Id))
			{
				this.Clients.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeClientCommunicationsValue { get; set; } = true;

		public bool ShouldSerializeClientCommunications()
		{
			return this.ShouldSerializeClientCommunicationsValue;
		}

		public void AddClientCommunication(POCOClientCommunication item)
		{
			if (!this.ClientCommunications.Any(x => x.Id == item.Id))
			{
				this.ClientCommunications.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCountriesValue { get; set; } = true;

		public bool ShouldSerializeCountries()
		{
			return this.ShouldSerializeCountriesValue;
		}

		public void AddCountry(POCOCountry item)
		{
			if (!this.Countries.Any(x => x.Id == item.Id))
			{
				this.Countries.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCountryRequirementsValue { get; set; } = true;

		public bool ShouldSerializeCountryRequirements()
		{
			return this.ShouldSerializeCountryRequirementsValue;
		}

		public void AddCountryRequirement(POCOCountryRequirement item)
		{
			if (!this.CountryRequirements.Any(x => x.Id == item.Id))
			{
				this.CountryRequirements.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeDestinationsValue { get; set; } = true;

		public bool ShouldSerializeDestinations()
		{
			return this.ShouldSerializeDestinationsValue;
		}

		public void AddDestination(POCODestination item)
		{
			if (!this.Destinations.Any(x => x.Id == item.Id))
			{
				this.Destinations.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeEmployeesValue { get; set; } = true;

		public bool ShouldSerializeEmployees()
		{
			return this.ShouldSerializeEmployeesValue;
		}

		public void AddEmployee(POCOEmployee item)
		{
			if (!this.Employees.Any(x => x.Id == item.Id))
			{
				this.Employees.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeHandlersValue { get; set; } = true;

		public bool ShouldSerializeHandlers()
		{
			return this.ShouldSerializeHandlersValue;
		}

		public void AddHandler(POCOHandler item)
		{
			if (!this.Handlers.Any(x => x.Id == item.Id))
			{
				this.Handlers.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeHandlerPipelineStepsValue { get; set; } = true;

		public bool ShouldSerializeHandlerPipelineSteps()
		{
			return this.ShouldSerializeHandlerPipelineStepsValue;
		}

		public void AddHandlerPipelineStep(POCOHandlerPipelineStep item)
		{
			if (!this.HandlerPipelineSteps.Any(x => x.Id == item.Id))
			{
				this.HandlerPipelineSteps.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeOtherTransportsValue { get; set; } = true;

		public bool ShouldSerializeOtherTransports()
		{
			return this.ShouldSerializeOtherTransportsValue;
		}

		public void AddOtherTransport(POCOOtherTransport item)
		{
			if (!this.OtherTransports.Any(x => x.Id == item.Id))
			{
				this.OtherTransports.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePetsValue { get; set; } = true;

		public bool ShouldSerializePets()
		{
			return this.ShouldSerializePetsValue;
		}

		public void AddPet(POCOPet item)
		{
			if (!this.Pets.Any(x => x.Id == item.Id))
			{
				this.Pets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePipelinesValue { get; set; } = true;

		public bool ShouldSerializePipelines()
		{
			return this.ShouldSerializePipelinesValue;
		}

		public void AddPipeline(POCOPipeline item)
		{
			if (!this.Pipelines.Any(x => x.Id == item.Id))
			{
				this.Pipelines.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStatusValue { get; set; } = true;

		public bool ShouldSerializePipelineStatus()
		{
			return this.ShouldSerializePipelineStatusValue;
		}

		public void AddPipelineStatus(POCOPipelineStatus item)
		{
			if (!this.PipelineStatus.Any(x => x.Id == item.Id))
			{
				this.PipelineStatus.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepsValue { get; set; } = true;

		public bool ShouldSerializePipelineSteps()
		{
			return this.ShouldSerializePipelineStepsValue;
		}

		public void AddPipelineStep(POCOPipelineStep item)
		{
			if (!this.PipelineSteps.Any(x => x.Id == item.Id))
			{
				this.PipelineSteps.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepDestinationsValue { get; set; } = true;

		public bool ShouldSerializePipelineStepDestinations()
		{
			return this.ShouldSerializePipelineStepDestinationsValue;
		}

		public void AddPipelineStepDestination(POCOPipelineStepDestination item)
		{
			if (!this.PipelineStepDestinations.Any(x => x.Id == item.Id))
			{
				this.PipelineStepDestinations.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepNotesValue { get; set; } = true;

		public bool ShouldSerializePipelineStepNotes()
		{
			return this.ShouldSerializePipelineStepNotesValue;
		}

		public void AddPipelineStepNote(POCOPipelineStepNote item)
		{
			if (!this.PipelineStepNotes.Any(x => x.Id == item.Id))
			{
				this.PipelineStepNotes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepStatusValue { get; set; } = true;

		public bool ShouldSerializePipelineStepStatus()
		{
			return this.ShouldSerializePipelineStepStatusValue;
		}

		public void AddPipelineStepStatus(POCOPipelineStepStatus item)
		{
			if (!this.PipelineStepStatus.Any(x => x.Id == item.Id))
			{
				this.PipelineStepStatus.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepStepRequirementsValue { get; set; } = true;

		public bool ShouldSerializePipelineStepStepRequirements()
		{
			return this.ShouldSerializePipelineStepStepRequirementsValue;
		}

		public void AddPipelineStepStepRequirement(POCOPipelineStepStepRequirement item)
		{
			if (!this.PipelineStepStepRequirements.Any(x => x.Id == item.Id))
			{
				this.PipelineStepStepRequirements.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesValue { get; set; } = true;

		public bool ShouldSerializeSales()
		{
			return this.ShouldSerializeSalesValue;
		}

		public void AddSale(POCOSale item)
		{
			if (!this.Sales.Any(x => x.Id == item.Id))
			{
				this.Sales.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSpeciesValue { get; set; } = true;

		public bool ShouldSerializeSpecies()
		{
			return this.ShouldSerializeSpeciesValue;
		}

		public void AddSpecies(POCOSpecies item)
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
    <Hash>76dc08a2992ca920839977a1378d99fa</Hash>
</Codenesium>*/