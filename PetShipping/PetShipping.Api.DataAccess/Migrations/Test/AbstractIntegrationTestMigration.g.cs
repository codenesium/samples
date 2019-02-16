using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractIntegrationTestMigration
	{
		protected ApplicationDbContext Context { get; private set; }

		public AbstractIntegrationTestMigration(ApplicationDbContext context)
		{
			this.Context = context;
		}

		public virtual async Task Migrate()
		{
			var airlineItem1 = new Airline();
			airlineItem1.SetProperties(1, "A");
			this.Context.Airlines.Add(airlineItem1);

			var airTransportItem1 = new AirTransport();
			airTransportItem1.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			this.Context.AirTransports.Add(airTransportItem1);

			var breedItem1 = new Breed();
			breedItem1.SetProperties(1, "A", 1);
			this.Context.Breeds.Add(breedItem1);

			var countryItem1 = new Country();
			countryItem1.SetProperties(1, "A");
			this.Context.Countries.Add(countryItem1);

			var countryRequirementItem1 = new CountryRequirement();
			countryRequirementItem1.SetProperties(1, 1, "A");
			this.Context.CountryRequirements.Add(countryRequirementItem1);

			var customerItem1 = new Customer();
			customerItem1.SetProperties(1, "A", "A", "A", "A", "A");
			this.Context.Customers.Add(customerItem1);

			var customerCommunicationItem1 = new CustomerCommunication();
			customerCommunicationItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			this.Context.CustomerCommunications.Add(customerCommunicationItem1);

			var destinationItem1 = new Destination();
			destinationItem1.SetProperties(1, 1, "A", 1);
			this.Context.Destinations.Add(destinationItem1);

			var employeeItem1 = new Employee();
			employeeItem1.SetProperties(1, "A", true, true, "A");
			this.Context.Employees.Add(employeeItem1);

			var handlerItem1 = new Handler();
			handlerItem1.SetProperties(1, 1, "A", "A", "A", "A");
			this.Context.Handlers.Add(handlerItem1);

			var handlerPipelineStepItem1 = new HandlerPipelineStep();
			handlerPipelineStepItem1.SetProperties(1, 1, 1);
			this.Context.HandlerPipelineSteps.Add(handlerPipelineStepItem1);

			var otherTransportItem1 = new OtherTransport();
			otherTransportItem1.SetProperties(1, 1, 1);
			this.Context.OtherTransports.Add(otherTransportItem1);

			var petItem1 = new Pet();
			petItem1.SetProperties(1, 1, 1, "A", 1);
			this.Context.Pets.Add(petItem1);

			var pipelineItem1 = new Pipeline();
			pipelineItem1.SetProperties(1, 1, 1);
			this.Context.Pipelines.Add(pipelineItem1);

			var pipelineStatuItem1 = new PipelineStatu();
			pipelineStatuItem1.SetProperties(1, "A");
			this.Context.PipelineStatus.Add(pipelineStatuItem1);

			var pipelineStepItem1 = new PipelineStep();
			pipelineStepItem1.SetProperties(1, "A", 1, 1);
			this.Context.PipelineSteps.Add(pipelineStepItem1);

			var pipelineStepDestinationItem1 = new PipelineStepDestination();
			pipelineStepDestinationItem1.SetProperties(1, 1, 1);
			this.Context.PipelineStepDestinations.Add(pipelineStepDestinationItem1);

			var pipelineStepNoteItem1 = new PipelineStepNote();
			pipelineStepNoteItem1.SetProperties(1, 1, "A", 1);
			this.Context.PipelineStepNotes.Add(pipelineStepNoteItem1);

			var pipelineStepStatuItem1 = new PipelineStepStatu();
			pipelineStepStatuItem1.SetProperties(1, "A");
			this.Context.PipelineStepStatus.Add(pipelineStepStatuItem1);

			var pipelineStepStepRequirementItem1 = new PipelineStepStepRequirement();
			pipelineStepStepRequirementItem1.SetProperties(1, "A", 1, true);
			this.Context.PipelineStepStepRequirements.Add(pipelineStepStepRequirementItem1);

			var saleItem1 = new Sale();
			saleItem1.SetProperties(1, 1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			this.Context.Sales.Add(saleItem1);

			var speciesItem1 = new Species();
			speciesItem1.SetProperties(1, "A");
			this.Context.Species.Add(speciesItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>fe7807e0c6a434140fcbae32122bd099</Hash>
</Codenesium>*/