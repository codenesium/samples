using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
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
			var breedItem1 = new Breed();
			breedItem1.SetProperties(1, "A");
			this.context.Breeds.Add(breedItem1);

			var paymentTypeItem1 = new PaymentType();
			paymentTypeItem1.SetProperties(1, "A");
			this.context.PaymentTypes.Add(paymentTypeItem1);

			var penItem1 = new Pen();
			penItem1.SetProperties(1, "A");
			this.context.Pens.Add(penItem1);

			var petItem1 = new Pet();
			petItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1, 1m, 1);
			this.context.Pets.Add(petItem1);

			var saleItem1 = new Sale();
			saleItem1.SetProperties(1m, "A", 1, "A", 1, 1, "A");
			this.context.Sales.Add(saleItem1);

			var speciesItem1 = new Species();
			speciesItem1.SetProperties(1, "A");
			this.context.Species.Add(speciesItem1);

			await this.context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>221283f04dd60073f1bc2de2069e8196</Hash>
</Codenesium>*/