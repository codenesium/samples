using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
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
			var adminItem1 = new Admin();
			adminItem1.SetProperties(1, "A", "A", "A", "A", "A", "A");
			this.Context.Admins.Add(adminItem1);

			var cityItem1 = new City();
			cityItem1.SetProperties(1, "A", 1);
			this.Context.Cities.Add(cityItem1);

			var countryItem1 = new Country();
			countryItem1.SetProperties(1, "A");
			this.Context.Countries.Add(countryItem1);

			var customerItem1 = new Customer();
			customerItem1.SetProperties(1, "A", "A", "A", "A");
			this.Context.Customers.Add(customerItem1);

			var eventItem1 = new Event();
			eventItem1.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.Events.Add(eventItem1);

			var provinceItem1 = new Province();
			provinceItem1.SetProperties(1, 1, "A");
			this.Context.Provinces.Add(provinceItem1);

			var saleItem1 = new Sale();
			saleItem1.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			this.Context.Sales.Add(saleItem1);

			var saleTicketsItem1 = new SaleTickets();
			saleTicketsItem1.SetProperties(1, 1, 1);
			this.Context.SaleTickets.Add(saleTicketsItem1);

			var ticketItem1 = new Ticket();
			ticketItem1.SetProperties(1, "A", 1);
			this.Context.Tickets.Add(ticketItem1);

			var ticketStatusItem1 = new TicketStatus();
			ticketStatusItem1.SetProperties(1, "A");
			this.Context.TicketStatus.Add(ticketStatusItem1);

			var transactionItem1 = new Transaction();
			transactionItem1.SetProperties(1, 1m, "A", 1);
			this.Context.Transactions.Add(transactionItem1);

			var transactionStatusItem1 = new TransactionStatus();
			transactionStatusItem1.SetProperties(1, "A");
			this.Context.TransactionStatus.Add(transactionStatusItem1);

			var venueItem1 = new Venue();
			venueItem1.SetProperties(1, "A", "A", 1, "A", "A", "A", "A", 1, "A");
			this.Context.Venues.Add(venueItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>e84b9d3ff4e55ccb708f951f3b56b76c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/