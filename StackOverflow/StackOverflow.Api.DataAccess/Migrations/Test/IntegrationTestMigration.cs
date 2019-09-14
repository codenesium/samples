using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
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
    <Hash>786e6bc55e816a938c56c6f2cc0bd450</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/