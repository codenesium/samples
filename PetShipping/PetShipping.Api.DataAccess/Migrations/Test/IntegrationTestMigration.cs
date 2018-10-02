using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public class IntegrationTestMigration
	{
		private ApplicationDbContext context;

		public IntegrationTestMigration(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async void Migrate()
		{
			var airlineItem1 = new Airline();
			airlineItem1.SetProperties(1, "A");
			this.context.Airlines.Add(airlineItem1);

			var airTransportItem1 = new AirTransport();
			airTransportItem1.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			this.context.AirTransports.Add(airTransportItem1);

			var breedItem1 = new Breed();
			breedItem1.SetProperties(1, "A", 1);
			this.context.Breeds.Add(breedItem1);

			var clientItem1 = new Client();
			clientItem1.SetProperties("A", "A", 1, "A", "A", "A");
			this.context.Clients.Add(clientItem1);

			var clientCommunicationItem1 = new ClientCommunication();
			clientCommunicationItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			this.context.ClientCommunications.Add(clientCommunicationItem1);

			var countryItem1 = new Country();
			countryItem1.SetProperties(1, "A");
			this.context.Countries.Add(countryItem1);

			var countryRequirementItem1 = new CountryRequirement();
			countryRequirementItem1.SetProperties(1, "A", 1);
			this.context.CountryRequirements.Add(countryRequirementItem1);

			var destinationItem1 = new Destination();
			destinationItem1.SetProperties(1, 1, "A", 1);
			this.context.Destinations.Add(destinationItem1);

			var employeeItem1 = new Employee();
			employeeItem1.SetProperties("A", 1, true, true, "A");
			this.context.Employees.Add(employeeItem1);

			var handlerItem1 = new Handler();
			handlerItem1.SetProperties(1, "A", "A", 1, "A", "A");
			this.context.Handlers.Add(handlerItem1);

			var handlerPipelineStepItem1 = new HandlerPipelineStep();
			handlerPipelineStepItem1.SetProperties(1, 1, 1);
			this.context.HandlerPipelineSteps.Add(handlerPipelineStepItem1);

			var otherTransportItem1 = new OtherTransport();
			otherTransportItem1.SetProperties(1, 1, 1);
			this.context.OtherTransports.Add(otherTransportItem1);

			var petItem1 = new Pet();
			petItem1.SetProperties(1, 1, 1, "A", 1);
			this.context.Pets.Add(petItem1);

			var pipelineItem1 = new Pipeline();
			pipelineItem1.SetProperties(1, 1, 1);
			this.context.Pipelines.Add(pipelineItem1);

			var pipelineStatuItem1 = new PipelineStatu();
			pipelineStatuItem1.SetProperties(1, "A");
			this.context.PipelineStatus.Add(pipelineStatuItem1);

			var pipelineStepItem1 = new PipelineStep();
			pipelineStepItem1.SetProperties(1, "A", 1, 1);
			this.context.PipelineSteps.Add(pipelineStepItem1);

			var pipelineStepDestinationItem1 = new PipelineStepDestination();
			pipelineStepDestinationItem1.SetProperties(1, 1, 1);
			this.context.PipelineStepDestinations.Add(pipelineStepDestinationItem1);

			var pipelineStepNoteItem1 = new PipelineStepNote();
			pipelineStepNoteItem1.SetProperties(1, 1, "A", 1);
			this.context.PipelineStepNotes.Add(pipelineStepNoteItem1);

			var pipelineStepStatuItem1 = new PipelineStepStatu();
			pipelineStepStatuItem1.SetProperties(1, "A");
			this.context.PipelineStepStatus.Add(pipelineStepStatuItem1);

			var pipelineStepStepRequirementItem1 = new PipelineStepStepRequirement();
			pipelineStepStepRequirementItem1.SetProperties("A", 1, 1, true);
			this.context.PipelineStepStepRequirements.Add(pipelineStepStepRequirementItem1);

			var saleItem1 = new Sale();
			saleItem1.SetProperties(1m, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			this.context.Sales.Add(saleItem1);

			var speciesItem1 = new Species();
			speciesItem1.SetProperties(1, "A");
			this.context.Species.Add(speciesItem1);

			await this.context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>b82551c6a4987b76d5d8e640c3ca2666</Hash>
</Codenesium>*/