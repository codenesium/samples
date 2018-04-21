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
			var record = new EFAWBuildVersion();

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
			var record = this.SearchLinqEF(x => x.SystemInformationID == systemInformationID).FirstOrDefault();
			if (record == null)
			{
				throw new Exception($"Unable to find id:{systemInformationID}");
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
			var record = this.SearchLinqEF(x => x.SystemInformationID == systemInformationID).FirstOrDefault();

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

		public virtual ApiResponse GetById(int systemInformationID)
		{
			return this.SearchLinqPOCO(x => x.SystemInformationID == systemInformationID);
		}

		public virtual POCOAWBuildVersion GetByIdDirect(int systemInformationID)
		{
			return this.SearchLinqPOCO(x => x.SystemInformationID == systemInformationID).AWBuildVersions.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOAWBuildVersion> GetWhereDirect(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).AWBuildVersions;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			List<EFAWBuildVersion> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.AWBuildVersionMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			List<EFAWBuildVersion> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.AWBuildVersionMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFAWBuildVersion> SearchLinqEF(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFAWBuildVersion> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>63d42004c10f71fef022ffe6295dc496</Hash>
</Codenesium>*/