using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractOrganizationRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractOrganizationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOOrganization>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOOrganization> Get(int id)
		{
			Organization record = await this.GetById(id);

			return this.Mapper.OrganizationMapEFToPOCO(record);
		}

		public async virtual Task<POCOOrganization> Create(
			ApiOrganizationModel model)
		{
			Organization record = new Organization();

			this.Mapper.OrganizationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Organization>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.OrganizationMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiOrganizationModel model)
		{
			Organization record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.OrganizationMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Organization record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Organization>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOOrganization> Name(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOOrganization>> Where(Expression<Func<Organization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOOrganization> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOOrganization>> SearchLinqPOCO(Expression<Func<Organization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOOrganization> response = new List<POCOOrganization>();
			List<Organization> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.OrganizationMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Organization>> SearchLinqEF(Expression<Func<Organization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Organization.Id)} ASC";
			}
			return await this.Context.Set<Organization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Organization>();
		}

		private async Task<List<Organization>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Organization.Id)} ASC";
			}

			return await this.Context.Set<Organization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Organization>();
		}

		private async Task<Organization> GetById(int id)
		{
			List<Organization> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e9dd728fd83b505365e84fae8eb15c7f</Hash>
</Codenesium>*/