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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractAWBuildVersionRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			string database_Version,
			DateTime versionDate,
			DateTime modifiedDate)
		{
			var record = new EFAWBuildVersion();

			MapPOCOToEF(
				0,
				database_Version,
				versionDate,
				modifiedDate,
				record);

			this.context.Set<EFAWBuildVersion>().Add(record);
			this.context.SaveChanges();
			return record.SystemInformationID;
		}

		public virtual void Update(
			int systemInformationID,
			string database_Version,
			DateTime versionDate,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.SystemInformationID == systemInformationID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{systemInformationID}");
			}
			else
			{
				MapPOCOToEF(
					systemInformationID,
					database_Version,
					versionDate,
					modifiedDate,
					record);
				this.context.SaveChanges();
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
				this.context.Set<EFAWBuildVersion>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int systemInformationID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SystemInformationID == systemInformationID, response);
			return response;
		}

		public virtual POCOAWBuildVersion GetByIdDirect(int systemInformationID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SystemInformationID == systemInformationID, response);
			return response.AWBuildVersions.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOAWBuildVersion> GetWhereDirect(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.AWBuildVersions;
		}

		private void SearchLinqPOCO(Expression<Func<EFAWBuildVersion, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFAWBuildVersion> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFAWBuildVersion> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFAWBuildVersion> SearchLinqEF(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFAWBuildVersion> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int systemInformationID,
			string database_Version,
			DateTime versionDate,
			DateTime modifiedDate,
			EFAWBuildVersion efAWBuildVersion)
		{
			efAWBuildVersion.SetProperties(systemInformationID, database_Version, versionDate.ToDateTime(), modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFAWBuildVersion efAWBuildVersion,
			Response response)
		{
			if (efAWBuildVersion == null)
			{
				return;
			}

			response.AddAWBuildVersion(new POCOAWBuildVersion(efAWBuildVersion.SystemInformationID, efAWBuildVersion.Database_Version, efAWBuildVersion.VersionDate.ToDateTime(), efAWBuildVersion.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>4c432d9386aa489ab97a7af81a1fc476</Hash>
</Codenesium>*/