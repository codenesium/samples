using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.DataAccess
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
			var customerItem1 = new Customer();
			customerItem1.SetProperties(1, "A", "A", "A", "A");
			this.Context.Customers.Add(customerItem1);

			var productItem1 = new Product();
			productItem1.SetProperties(1, true, "A", "A", 1m, 1);
			this.Context.Products.Add(productItem1);

			var saleItem1 = new Sale();
			saleItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			this.Context.Sales.Add(saleItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>8abb9d73b34d2dbe5ba15bf042ae8b57</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/