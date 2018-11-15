using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>253e620809927fc58b277930a19aa3fe</Hash>
</Codenesium>*/