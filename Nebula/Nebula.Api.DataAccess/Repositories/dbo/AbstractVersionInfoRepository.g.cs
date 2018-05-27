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
	public abstract class AbstractVersionInfoRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALVersionInfoMapper Mapper { get; }

		public AbstractVersionInfoRepository(
			IDALVersionInfoMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOVersionInfo>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOVersionInfo> Get(long version)
		{
			VersionInfo record = await this.GetById(version);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOVersionInfo> Create(
			DTOVersionInfo dto)
		{
			VersionInfo record = new VersionInfo();

			this.Mapper.MapDTOToEF(
				default (long),
				dto,
				record);

			this.Context.Set<VersionInfo>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			long version,
			DTOVersionInfo dto)
		{
			VersionInfo record = await this.GetById(version);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{version}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					version,
					dto,
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

		public async Task<DTOVersionInfo> GetVersion(long version)
		{
			var records = await this.SearchLinqDTO(x => x.Version == version);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOVersionInfo>> Where(Expression<Func<VersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOVersionInfo> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOVersionInfo>> SearchLinqDTO(Expression<Func<VersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOVersionInfo> response = new List<DTOVersionInfo>();
			List<VersionInfo> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>3503747c99498b30be1b6209dc214e79</Hash>
</Codenesium>*/