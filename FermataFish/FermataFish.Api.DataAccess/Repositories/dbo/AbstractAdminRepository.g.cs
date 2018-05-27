using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractAdminRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALAdminMapper Mapper { get; }

		public AbstractAdminRepository(
			IDALAdminMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOAdmin>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOAdmin> Get(int id)
		{
			Admin record = await this.GetById(id);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOAdmin> Create(
			DTOAdmin dto)
		{
			Admin record = new Admin();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Admin>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int id,
			DTOAdmin dto)
		{
			Admin record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					id,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Admin record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Admin>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOAdmin>> Where(Expression<Func<Admin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOAdmin> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOAdmin>> SearchLinqDTO(Expression<Func<Admin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOAdmin> response = new List<DTOAdmin>();
			List<Admin> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<Admin>> SearchLinqEF(Expression<Func<Admin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Admin.Id)} ASC";
			}
			return await this.Context.Set<Admin>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Admin>();
		}

		private async Task<List<Admin>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Admin.Id)} ASC";
			}

			return await this.Context.Set<Admin>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Admin>();
		}

		private async Task<Admin> GetById(int id)
		{
			List<Admin> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>707f125e568eb7db559cc30675a79680</Hash>
</Codenesium>*/