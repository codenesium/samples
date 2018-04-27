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

		public virtual ApiResponse GetById(long version)
		{
			return this.SearchLinqPOCO(x => x.Version == version);
		}

		public virtual POCOVersionInfo GetByIdDirect(long version)
		{
			return this.SearchLinqPOCO(x => x.Version == version).VersionInfoes.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOVersionInfo> GetWhereDirect(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).VersionInfoes;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFVersionInfo> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.VersionInfoMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFVersionInfo> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.VersionInfoMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFVersionInfo> SearchLinqEF(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFVersionInfo> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>7fad492819bd687ce02131d5e47fe1ac</Hash>
</Codenesium>*/