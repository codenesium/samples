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
		protected IObjectMapper mapper;

		public AbstractAWBuildVersionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			AWBuildVersionModel model)
		{
			var record = new EFAWBuildVersion();

			this.mapper.AWBuildVersionMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFAWBuildVersion>().Add(record);
			this.context.SaveChanges();
			return record.SystemInformationID;
		}

		public virtual void Update(
			int systemInformationID,
			AWBuildVersionModel model)
		{
			var record = this.SearchLinqEF(x => x.SystemInformationID == systemInformationID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{systemInformationID}");
			}
			else
			{
				this.mapper.AWBuildVersionMapModelToEF(
					systemInformationID,
					model,
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

		public virtual ApiResponse GetById(int systemInformationID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SystemInformationID == systemInformationID, response);
			return response;
		}

		public virtual POCOAWBuildVersion GetByIdDirect(int systemInformationID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SystemInformationID == systemInformationID, response);
			return response.AWBuildVersions.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOAWBuildVersion> GetWhereDirect(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.AWBuildVersions;
		}

		private void SearchLinqPOCO(Expression<Func<EFAWBuildVersion, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFAWBuildVersion> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.AWBuildVersionMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFAWBuildVersion> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.AWBuildVersionMapEFToPOCO(x, response));
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
    <Hash>f7abcb7c71b9df30448a4eec0e68759d</Hash>
</Codenesium>*/