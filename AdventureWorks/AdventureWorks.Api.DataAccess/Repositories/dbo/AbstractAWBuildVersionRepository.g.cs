using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractAWBuildVersionRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractAWBuildVersionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			AWBuildVersionModel model)
		{
			EFAWBuildVersion record = new EFAWBuildVersion();

			this.Mapper.AWBuildVersionMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFAWBuildVersion>().Add(record);
			this.Context.SaveChanges();
			return record.SystemInformationID;
		}

		public virtual void Update(
			int systemInformationID,
			AWBuildVersionModel model)
		{
			EFAWBuildVersion record = this.SearchLinqEF(x => x.SystemInformationID == systemInformationID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int systemInformationID)
		{
			EFAWBuildVersion record = this.SearchLinqEF(x => x.SystemInformationID == systemInformationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFAWBuildVersion>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOAWBuildVersion Get(int systemInformationID)
		{
			return this.SearchLinqPOCO(x => x.SystemInformationID == systemInformationID).FirstOrDefault();
		}

		public virtual List<POCOAWBuildVersion> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOAWBuildVersion> Where(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOAWBuildVersion> SearchLinqPOCO(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAWBuildVersion> response = new List<POCOAWBuildVersion>();
			List<EFAWBuildVersion> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.AWBuildVersionMapEFToPOCO(x)));
			return response;
		}

		private List<EFAWBuildVersion> SearchLinqEF(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy("SystemInformationID ASC").Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
			else
			{
				return this.Context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
		}

		private List<EFAWBuildVersion> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy("SystemInformationID ASC").Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
			else
			{
				return this.Context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>aaf778b8f450e295d773c7a2396fb70c</Hash>
</Codenesium>*/