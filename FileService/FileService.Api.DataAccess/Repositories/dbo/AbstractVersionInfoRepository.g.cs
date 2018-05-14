using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractVersionInfoRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractVersionInfoRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOVersionInfo Get(long version)
		{
			return this.SearchLinqPOCO(x => x.Version == version).FirstOrDefault();
		}

		public virtual POCOVersionInfo Create(
			VersionInfoModel model)
		{
			VersionInfo record = new VersionInfo();

			this.Mapper.VersionInfoMapModelToEF(
				default (long),
				model,
				record);

			this.Context.Set<VersionInfo>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.VersionInfoMapEFToPOCO(record);
		}

		public virtual void Update(
			long version,
			VersionInfoModel model)
		{
			VersionInfo record = this.SearchLinqEF(x => x.Version == version).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			long version)
		{
			VersionInfo record = this.SearchLinqEF(x => x.Version == version).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VersionInfo>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOVersionInfo Version(long version)
		{
			return this.SearchLinqPOCO(x => x.Version == version).FirstOrDefault();
		}

		protected List<POCOVersionInfo> Where(Expression<Func<VersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOVersionInfo> SearchLinqPOCO(Expression<Func<VersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOVersionInfo> response = new List<POCOVersionInfo>();
			List<VersionInfo> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.VersionInfoMapEFToPOCO(x)));
			return response;
		}

		private List<VersionInfo> SearchLinqEF(Expression<Func<VersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(VersionInfo.Version)} ASC";
			}
			return this.Context.Set<VersionInfo>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<VersionInfo>();
		}

		private List<VersionInfo> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(VersionInfo.Version)} ASC";
			}

			return this.Context.Set<VersionInfo>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<VersionInfo>();
		}
	}
}

/*<Codenesium>
    <Hash>367c430dbe19a324be383524ceefbdb6</Hash>
</Codenesium>*/