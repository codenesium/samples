using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
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
    <Hash>4d32b4f199cf87536b6f9a878657f6b4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/