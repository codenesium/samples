using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractAWBuildVersionRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractAWBuildVersionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOAWBuildVersion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOAWBuildVersion> Get(int systemInformationID)
		{
			AWBuildVersion record = await this.GetById(systemInformationID);

			return this.Mapper.AWBuildVersionMapEFToPOCO(record);
		}

		public async virtual Task<POCOAWBuildVersion> Create(
			ApiAWBuildVersionModel model)
		{
			AWBuildVersion record = new AWBuildVersion();

			this.Mapper.AWBuildVersionMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<AWBuildVersion>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.AWBuildVersionMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int systemInformationID,
			ApiAWBuildVersionModel model)
		{
			AWBuildVersion record = await this.GetById(systemInformationID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{systemInformationID}");
			}
			else
			{
				this.Mapper.AWBuildVersionMapModelToEF(
					systemInformationID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int systemInformationID)
		{
			AWBuildVersion record = await this.GetById(systemInformationID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<AWBuildVersion>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOAWBuildVersion>> Where(Expression<Func<AWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAWBuildVersion> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOAWBuildVersion>> SearchLinqPOCO(Expression<Func<AWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAWBuildVersion> response = new List<POCOAWBuildVersion>();
			List<AWBuildVersion> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.AWBuildVersionMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<AWBuildVersion>> SearchLinqEF(Expression<Func<AWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AWBuildVersion.SystemInformationID)} ASC";
			}
			return await this.Context.Set<AWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<AWBuildVersion>();
		}

		private async Task<List<AWBuildVersion>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AWBuildVersion.SystemInformationID)} ASC";
			}

			return await this.Context.Set<AWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<AWBuildVersion>();
		}

		private async Task<AWBuildVersion> GetById(int systemInformationID)
		{
			List<AWBuildVersion> records = await this.SearchLinqEF(x => x.SystemInformationID == systemInformationID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>606ae2a924268af201d229f1c4af5713</Hash>
</Codenesium>*/