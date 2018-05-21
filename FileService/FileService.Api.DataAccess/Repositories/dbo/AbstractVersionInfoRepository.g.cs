using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractVersionInfoRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractVersionInfoRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOVersionInfo>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOVersionInfo> Get(long version)
		{
			VersionInfo record = await this.GetById(version);

			return this.Mapper.VersionInfoMapEFToPOCO(record);
		}

		public async virtual Task<POCOVersionInfo> Create(
			ApiVersionInfoModel model)
		{
			VersionInfo record = new VersionInfo();

			this.Mapper.VersionInfoMapModelToEF(
				default (long),
				model,
				record);

			this.Context.Set<VersionInfo>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.VersionInfoMapEFToPOCO(record);
		}

		public async virtual Task Update(
			long version,
			ApiVersionInfoModel model)
		{
			VersionInfo record = await this.GetById(version);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{version}");
			}
			else
			{
				this.Mapper.VersionInfoMapModelToEF(
					version,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			long version)
		{
			VersionInfo record = await this.GetById(version);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VersionInfo>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOVersionInfo> Version(long version)
		{
			var records = await this.SearchLinqPOCO(x => x.Version == version);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOVersionInfo>> Where(Expression<Func<VersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOVersionInfo> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOVersionInfo>> SearchLinqPOCO(Expression<Func<VersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOVersionInfo> response = new List<POCOVersionInfo>();
			List<VersionInfo> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.VersionInfoMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<VersionInfo>> SearchLinqEF(Expression<Func<VersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(VersionInfo.Version)} ASC";
			}
			return await this.Context.Set<VersionInfo>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<VersionInfo>();
		}

		private async Task<List<VersionInfo>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(VersionInfo.Version)} ASC";
			}

			return await this.Context.Set<VersionInfo>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<VersionInfo>();
		}

		private async Task<VersionInfo> GetById(long version)
		{
			List<VersionInfo> records = await this.SearchLinqEF(x => x.Version == version);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f1796bb74058349b5845b79df504a706</Hash>
</Codenesium>*/