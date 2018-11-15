using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
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
    <Hash>1c406b8716f4c680ec3317263673beab</Hash>
</Codenesium>*/