using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
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
    <Hash>3289f7a868bbe50f10ebd1672366089c</Hash>
</Codenesium>*/