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

		public virtual List<POCOAWBuildVersion> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOAWBuildVersion Get(int systemInformationID)
		{
			return this.SearchLinqPOCO(x => x.SystemInformationID == systemInformationID).FirstOrDefault();
		}

		public virtual POCOAWBuildVersion Create(
			ApiAWBuildVersionModel model)
		{
			AWBuildVersion record = new AWBuildVersion();

			this.Mapper.AWBuildVersionMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<AWBuildVersion>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.AWBuildVersionMapEFToPOCO(record);
		}

		public virtual void Update(
			int systemInformationID,
			ApiAWBuildVersionModel model)
		{
			AWBuildVersion record = this.SearchLinqEF(x => x.SystemInformationID == systemInformationID).FirstOrDefault();
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
			AWBuildVersion record = this.SearchLinqEF(x => x.SystemInformationID == systemInformationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<AWBuildVersion>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOAWBuildVersion> Where(Expression<Func<AWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOAWBuildVersion> SearchLinqPOCO(Expression<Func<AWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAWBuildVersion> response = new List<POCOAWBuildVersion>();
			List<AWBuildVersion> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.AWBuildVersionMapEFToPOCO(x)));
			return response;
		}

		private List<AWBuildVersion> SearchLinqEF(Expression<Func<AWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AWBuildVersion.SystemInformationID)} ASC";
			}
			return this.Context.Set<AWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<AWBuildVersion>();
		}

		private List<AWBuildVersion> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AWBuildVersion.SystemInformationID)} ASC";
			}

			return this.Context.Set<AWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<AWBuildVersion>();
		}
	}
}

/*<Codenesium>
    <Hash>0dcbc953f8262b10e9c0c9cfd97f53eb</Hash>
</Codenesium>*/