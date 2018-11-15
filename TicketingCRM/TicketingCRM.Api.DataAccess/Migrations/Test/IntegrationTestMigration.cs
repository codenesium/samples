using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public class IntegrationTestMigration : AbstractIntegrationTestMigration
	{
		public IntegrationTestMigration(ApplicationDbContext context)
			: base(context)
		{
		}

		public override async void Migrate()
		{
			base.Migrate();
		}
	}
}

/*<Codenesium>
    <Hash>82f575324d687c6f27da0c824be70d78</Hash>
</Codenesium>*/