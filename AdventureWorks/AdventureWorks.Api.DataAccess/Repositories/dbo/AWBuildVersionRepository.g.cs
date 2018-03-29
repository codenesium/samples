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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractAWBuildVersionRepository(ILogger logger,
		                                        ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string database_Version,
		                          DateTime versionDate,
		                          DateTime modifiedDate)
		{
			var record = new EFAWBuildVersion ();

			MapPOCOToEF(0, database_Version,
			            versionDate,
			            modifiedDate, record);

			this._context.Set<EFAWBuildVersion>().Add(record);
			this._context.SaveChanges();
			return record.SystemInformationID;
		}

		public virtual void Update(int systemInformationID, string database_Version,
		                           DateTime versionDate,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.SystemInformationID == systemInformationID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",systemInformationID);
			}
			else
			{
				MapPOCOToEF(systemInformationID,  database_Version,
				            versionDate,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int systemInformationID)
		{
			var record = this.SearchLinqEF(x => x.SystemInformationID == systemInformationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFAWBuildVersion>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int systemInformationID, Response response)
		{
			this.SearchLinqPOCO(x => x.SystemInformationID == systemInformationID,response);
		}

		protected virtual List<EFAWBuildVersion> SearchLinqEF(Expression<Func<EFAWBuildVersion, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFAWBuildVersion> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFAWBuildVersion, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFAWBuildVersion, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFAWBuildVersion> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFAWBuildVersion> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int systemInformationID, string database_Version,
		                               DateTime versionDate,
		                               DateTime modifiedDate, EFAWBuildVersion   efAWBuildVersion)
		{
			efAWBuildVersion.SystemInformationID = systemInformationID;
			efAWBuildVersion.Database_Version = database_Version;
			efAWBuildVersion.VersionDate = versionDate;
			efAWBuildVersion.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFAWBuildVersion efAWBuildVersion,Response response)
		{
			if(efAWBuildVersion == null)
			{
				return;
			}
			response.AddAWBuildVersion(new POCOAWBuildVersion()
			{
				SystemInformationID = efAWBuildVersion.SystemInformationID,
				Database_Version = efAWBuildVersion.Database_Version,
				VersionDate = efAWBuildVersion.VersionDate.ToDateTime(),
				ModifiedDate = efAWBuildVersion.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>a6ec0e4f69c5d6447b4286b826192fad</Hash>
</Codenesium>*/