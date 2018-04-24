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
	public abstract class AbstractFileRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractFileRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			FileModel model)
		{
			EFFile record = new EFFile();

			this.Mapper.FileMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFFile>().Add(record);
			this.Context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			FileModel model)
		{
			EFFile record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.FileMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			EFFile record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFFile>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id);
		}

		public virtual POCOFile GetByIdDirect(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).Files.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOFile> GetWhereDirect(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Files;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFFile> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.FileMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFFile> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.FileMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFFile> SearchLinqEF(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFFile> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>7d00cd9cee33b4ecfd8578fa13b953c5</Hash>
</Codenesium>*/