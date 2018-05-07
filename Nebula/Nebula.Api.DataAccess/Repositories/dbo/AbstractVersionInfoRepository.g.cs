using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
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

		public virtual long Create(
			VersionInfoModel model)
		{
			EFVersionInfo record = new EFVersionInfo();

			this.Mapper.VersionInfoMapModelToEF(
				default (long),
				model,
				record);

			this.Context.Set<EFVersionInfo>().Add(record);
			this.Context.SaveChanges();
			return record.Version;
		}

		public virtual void Update(
			long version,
			VersionInfoModel model)
		{
			EFVersionInfo record = this.SearchLinqEF(x => x.Version == version).FirstOrDefault();
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
			EFVersionInfo record = this.SearchLinqEF(x => x.Version == version).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFVersionInfo>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOVersionInfo Get(long version)
		{
			return this.SearchLinqPOCO(x => x.Version == version).FirstOrDefault();
		}

		public virtual List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOVersionInfo> Where(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOVersionInfo> SearchLinqPOCO(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOVersionInfo> response = new List<POCOVersionInfo>();
			List<EFVersionInfo> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.VersionInfoMapEFToPOCO(x)));
			return response;
		}

		private List<EFVersionInfo> SearchLinqEF(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFVersionInfo>().Where(predicate).AsQueryable().OrderBy("Version ASC").Skip(skip).Take(take).ToList<EFVersionInfo>();
			}
			else
			{
				return this.Context.Set<EFVersionInfo>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFVersionInfo>();
			}
		}

		private List<EFVersionInfo> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFVersionInfo>().Where(predicate).AsQueryable().OrderBy("Version ASC").Skip(skip).Take(take).ToList<EFVersionInfo>();
			}
			else
			{
				return this.Context.Set<EFVersionInfo>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFVersionInfo>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>6178c8c195ff872eb7c803275b7450ff</Hash>
</Codenesium>*/