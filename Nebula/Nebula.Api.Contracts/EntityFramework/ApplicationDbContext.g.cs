using Microsoft.EntityFrameworkCore;
namespace NebulaNS.Api.Contracts
{
	public partial class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{}
	}
}

/*<Codenesium>
    <Hash>5a404e60607005f87adeb7eee7567fe7</Hash>
</Codenesium>*/