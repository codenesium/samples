using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShippingNS.Api.Client
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
			from.Countries.ForEach(x => this.AddCountry(x));
			from.CountryRequirements.ForEach(x => this.AddCountryRequirement(x));
			from.Customers.ForEach(x => this.AddCustomer(x));
			from.CustomerCommunications.ForEach(x => this.AddCustomerCommunication(x));
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

		public List<ApiAirlineClientResponseModel> Airlines { get; private set; } = new List<ApiAirlineClientResponseModel>();

		public List<ApiAirTransportClientResponseModel> AirTransports { get; private set; } = new List<ApiAirTransportClientResponseModel>();

		public List<ApiBreedClientResponseModel> Breeds { get; private set; } = new List<ApiBreedClientResponseModel>();

		public List<ApiCountryClientResponseModel> Countries { get; private set; } = new List<ApiCountryClientResponseModel>();

		public List<ApiCountryRequirementClientResponseModel> CountryRequirements { get; private set; } = new List<ApiCountryRequirementClientResponseModel>();

		public List<ApiCustomerClientResponseModel> Customers { get; private set; } = new List<ApiCustomerClientResponseModel>();

		public List<ApiCustomerCommunicationClientResponseModel> CustomerCommunications { get; private set; } = new List<ApiCustomerCommunicationClientResponseModel>();

		public List<ApiDestinationClientResponseModel> Destinations { get; private set; } = new List<ApiDestinationClientResponseModel>();

		public List<ApiEmployeeClientResponseModel> Employees { get; private set; } = new List<ApiEmployeeClientResponseModel>();

		public List<ApiHandlerClientResponseModel> Handlers { get; private set; } = new List<ApiHandlerClientResponseModel>();

		public List<ApiHandlerPipelineStepClientResponseModel> HandlerPipelineSteps { get; private set; } = new List<ApiHandlerPipelineStepClientResponseModel>();

		public List<ApiOtherTransportClientResponseModel> OtherTransports { get; private set; } = new List<ApiOtherTransportClientResponseModel>();

		public List<ApiPetClientResponseModel> Pets { get; private set; } = new List<ApiPetClientResponseModel>();

		public List<ApiPipelineClientResponseModel> Pipelines { get; private set; } = new List<ApiPipelineClientResponseModel>();

		public List<ApiPipelineStatusClientResponseModel> PipelineStatus { get; private set; } = new List<ApiPipelineStatusClientResponseModel>();

		public List<ApiPipelineStepClientResponseModel> PipelineSteps { get; private set; } = new List<ApiPipelineStepClientResponseModel>();

		public List<ApiPipelineStepDestinationClientResponseModel> PipelineStepDestinations { get; private set; } = new List<ApiPipelineStepDestinationClientResponseModel>();

		public List<ApiPipelineStepNoteClientResponseModel> PipelineStepNotes { get; private set; } = new List<ApiPipelineStepNoteClientResponseModel>();

		public List<ApiPipelineStepStatusClientResponseModel> PipelineStepStatus { get; private set; } = new List<ApiPipelineStepStatusClientResponseModel>();

		public List<ApiPipelineStepStepRequirementClientResponseModel> PipelineStepStepRequirements { get; private set; } = new List<ApiPipelineStepStepRequirementClientResponseModel>();

		public List<ApiSaleClientResponseModel> Sales { get; private set; } = new List<ApiSaleClientResponseModel>();

		public List<ApiSpeciesClientResponseModel> Species { get; private set; } = new List<ApiSpeciesClientResponseModel>();

		public void AddAirline(ApiAirlineClientResponseModel item)
		{
			if (!this.Airlines.Any(x => x.Id == item.Id))
			{
				this.Airlines.Add(item);
			}
		}

		public void AddAirTransport(ApiAirTransportClientResponseModel item)
		{
			if (!this.AirTransports.Any(x => x.AirlineId == item.AirlineId))
			{
				this.AirTransports.Add(item);
			}
		}

		public void AddBreed(ApiBreedClientResponseModel item)
		{
			if (!this.Breeds.Any(x => x.Id == item.Id))
			{
				this.Breeds.Add(item);
			}
		}

		public void AddCountry(ApiCountryClientResponseModel item)
		{
			if (!this.Countries.Any(x => x.Id == item.Id))
			{
				this.Countries.Add(item);
			}
		}

		public void AddCountryRequirement(ApiCountryRequirementClientResponseModel item)
		{
			if (!this.CountryRequirements.Any(x => x.Id == item.Id))
			{
				this.CountryRequirements.Add(item);
			}
		}

		public void AddCustomer(ApiCustomerClientResponseModel item)
		{
			if (!this.Customers.Any(x => x.Id == item.Id))
			{
				this.Customers.Add(item);
			}
		}

		public void AddCustomerCommunication(ApiCustomerCommunicationClientResponseModel item)
		{
			if (!this.CustomerCommunications.Any(x => x.Id == item.Id))
			{
				this.CustomerCommunications.Add(item);
			}
		}

		public void AddDestination(ApiDestinationClientResponseModel item)
		{
			if (!this.Destinations.Any(x => x.Id == item.Id))
			{
				this.Destinations.Add(item);
			}
		}

		public void AddEmployee(ApiEmployeeClientResponseModel item)
		{
			if (!this.Employees.Any(x => x.Id == item.Id))
			{
				this.Employees.Add(item);
			}
		}

		public void AddHandler(ApiHandlerClientResponseModel item)
		{
			if (!this.Handlers.Any(x => x.Id == item.Id))
			{
				this.Handlers.Add(item);
			}
		}

		public void AddHandlerPipelineStep(ApiHandlerPipelineStepClientResponseModel item)
		{
			if (!this.HandlerPipelineSteps.Any(x => x.Id == item.Id))
			{
				this.HandlerPipelineSteps.Add(item);
			}
		}

		public void AddOtherTransport(ApiOtherTransportClientResponseModel item)
		{
			if (!this.OtherTransports.Any(x => x.Id == item.Id))
			{
				this.OtherTransports.Add(item);
			}
		}

		public void AddPet(ApiPetClientResponseModel item)
		{
			if (!this.Pets.Any(x => x.Id == item.Id))
			{
				this.Pets.Add(item);
			}
		}

		public void AddPipeline(ApiPipelineClientResponseModel item)
		{
			if (!this.Pipelines.Any(x => x.Id == item.Id))
			{
				this.Pipelines.Add(item);
			}
		}

		public void AddPipelineStatus(ApiPipelineStatusClientResponseModel item)
		{
			if (!this.PipelineStatus.Any(x => x.Id == item.Id))
			{
				this.PipelineStatus.Add(item);
			}
		}

		public void AddPipelineStep(ApiPipelineStepClientResponseModel item)
		{
			if (!this.PipelineSteps.Any(x => x.Id == item.Id))
			{
				this.PipelineSteps.Add(item);
			}
		}

		public void AddPipelineStepDestination(ApiPipelineStepDestinationClientResponseModel item)
		{
			if (!this.PipelineStepDestinations.Any(x => x.Id == item.Id))
			{
				this.PipelineStepDestinations.Add(item);
			}
		}

		public void AddPipelineStepNote(ApiPipelineStepNoteClientResponseModel item)
		{
			if (!this.PipelineStepNotes.Any(x => x.Id == item.Id))
			{
				this.PipelineStepNotes.Add(item);
			}
		}

		public void AddPipelineStepStatus(ApiPipelineStepStatusClientResponseModel item)
		{
			if (!this.PipelineStepStatus.Any(x => x.Id == item.Id))
			{
				this.PipelineStepStatus.Add(item);
			}
		}

		public void AddPipelineStepStepRequirement(ApiPipelineStepStepRequirementClientResponseModel item)
		{
			if (!this.PipelineStepStepRequirements.Any(x => x.Id == item.Id))
			{
				this.PipelineStepStepRequirements.Add(item);
			}
		}

		public void AddSale(ApiSaleClientResponseModel item)
		{
			if (!this.Sales.Any(x => x.Id == item.Id))
			{
				this.Sales.Add(item);
			}
		}

		public void AddSpecies(ApiSpeciesClientResponseModel item)
		{
			if (!this.Species.Any(x => x.Id == item.Id))
			{
				this.Species.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>01f388136951f21e51c43411ed0a31fd</Hash>
</Codenesium>*/