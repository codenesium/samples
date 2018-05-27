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
		protected IDALAWBuildVersionMapper Mapper { get; }

		public AbstractAWBuildVersionRepository(
			IDALAWBuildVersionMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOAWBuildVersion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOAWBuildVersion> Get(int systemInformationID)
		{
			AWBuildVersion record = await this.GetById(systemInformationID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOAWBuildVersion> Create(
			DTOAWBuildVersion dto)
		{
			AWBuildVersion record = new AWBuildVersion();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<AWBuildVersion>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int systemInformationID,
			DTOAWBuildVersion dto)
		{
			AWBuildVersion record = await this.GetById(systemInformationID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{systemInformationID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					systemInformationID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		protected async Task<List<DTOAWBuildVersion>> Where(Expression<Func<AWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOAWBuildVersion> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOAWBuildVersion>> SearchLinqDTO(Expression<Func<AWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOAWBuildVersion> response = new List<DTOAWBuildVersion>();
			List<AWBuildVersion> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>c129d3fc39401b5fce07eb69e9fa069f</Hash>
</Codenesium>*/