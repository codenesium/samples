using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public class IntegrationTestMigration : AbstractIntegrationTestMigration
	{
		public IntegrationTestMigration(ApplicationDbContext context)
			: base(context)
		{
		}

		public override async Task Migrate()
		{
			await base.Migrate();
		}
	}
}

/*<Codenesium>
    <Hash>6f4e3a39afea9c3b3c4ca89a0ea83959</Hash>
</Codenesium>*/