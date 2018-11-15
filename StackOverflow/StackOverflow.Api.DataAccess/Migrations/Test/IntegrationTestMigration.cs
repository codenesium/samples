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

		public override async void Migrate()
		{
			base.Migrate();
		}
	}
}

/*<Codenesium>
    <Hash>56d75d9aef344a75292c93865b5ebf92</Hash>
</Codenesium>*/