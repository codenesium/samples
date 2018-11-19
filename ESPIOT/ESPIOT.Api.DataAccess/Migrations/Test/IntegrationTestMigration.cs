using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
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
    <Hash>551aa670bd2e55a076b55c7929c5f122</Hash>
</Codenesium>*/