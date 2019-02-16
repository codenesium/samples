using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
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
			var breedItem1 = new Breed();
			breedItem1.SetProperties(1, "A");
			this.Context.Breeds.Add(breedItem1);

			var paymentTypeItem1 = new PaymentType();
			paymentTypeItem1.SetProperties(1, "A");
			this.Context.PaymentTypes.Add(paymentTypeItem1);

			var penItem1 = new Pen();
			penItem1.SetProperties(1, "A");
			this.Context.Pens.Add(penItem1);

			var petItem1 = new Pet();
			petItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m, 1);
			this.Context.Pets.Add(petItem1);

			var saleItem1 = new Sale();
			saleItem1.SetProperties(1, 1m, "A", "A", 1, 1, "A");
			this.Context.Sales.Add(saleItem1);

			var speciesItem1 = new Species();
			speciesItem1.SetProperties(1, "A");
			this.Context.Species.Add(speciesItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>9e66ac2715406c405c290d4d941b287a</Hash>
</Codenesium>*/