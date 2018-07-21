using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        public class IntegrationTestMigration
        {
                private ApplicationDbContext context;

                public IntegrationTestMigration(ApplicationDbContext context)
                {
                        this.context = context;
                }

                public void Migrate()
                {
                        var adminItem1 = new Admin();
                        adminItem1.SetProperties("A", "A", 1, "A", "A", "A", "A");
                        this.context.Admins.Add(adminItem1);

                        var cityItem1 = new City();
                        cityItem1.SetProperties(1, "A", 1);
                        this.context.Cities.Add(cityItem1);

                        var countryItem1 = new Country();
                        countryItem1.SetProperties(1, "A");
                        this.context.Countries.Add(countryItem1);

                        var customerItem1 = new Customer();
                        customerItem1.SetProperties("A", "A", 1, "A", "A");
                        this.context.Customers.Add(customerItem1);

                        var eventItem1 = new Event();
                        eventItem1.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.Events.Add(eventItem1);

                        var provinceItem1 = new Province();
                        provinceItem1.SetProperties(1, 1, "A");
                        this.context.Provinces.Add(provinceItem1);

                        var saleItem1 = new Sale();
                        saleItem1.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        this.context.Sales.Add(saleItem1);

                        var saleTicketsItem1 = new SaleTickets();
                        saleTicketsItem1.SetProperties(1, 1, 1);
                        this.context.SaleTickets.Add(saleTicketsItem1);

                        var ticketItem1 = new Ticket();
                        ticketItem1.SetProperties(1, "A", 1);
                        this.context.Tickets.Add(ticketItem1);

                        var ticketStatusItem1 = new TicketStatus();
                        ticketStatusItem1.SetProperties(1, "A");
                        this.context.TicketStatus.Add(ticketStatusItem1);

                        var transactionItem1 = new Transaction();
                        transactionItem1.SetProperties(1m, "A", 1, 1);
                        this.context.Transactions.Add(transactionItem1);

                        var transactionStatusItem1 = new TransactionStatus();
                        transactionStatusItem1.SetProperties(1, "A");
                        this.context.TransactionStatus.Add(transactionStatusItem1);

                        var venueItem1 = new Venue();
                        venueItem1.SetProperties("A", "A", 1, "A", "A", 1, "A", "A", 1, "A");
                        this.context.Venues.Add(venueItem1);

                        this.context.SaveChanges();
                }
        }
}

/*<Codenesium>
    <Hash>58ee232c5f421c80c0c7a10c7a253e08</Hash>
</Codenesium>*/