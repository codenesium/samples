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

		public virtual List<POCOFile> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOFile Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOFile Create(
			FileModel model)
		{
			File record = new File();

			this.Mapper.FileMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<File>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.FileMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			FileModel model)
		{
			File record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
			File record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<File>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOFile> Where(Expression<Func<File, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOFile> SearchLinqPOCO(Expression<Func<File, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOFile> response = new List<POCOFile>();
			List<File> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.FileMapEFToPOCO(x)));
			return response;
		}

		private List<File> SearchLinqEF(Expression<Func<File, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(File.Id)} ASC";
			}
			return this.Context.Set<File>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<File>();
		}

		private List<File> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(File.Id)} ASC";
			}

			return this.Context.Set<File>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<File>();
		}
	}
}

/*<Codenesium>
    <Hash>31028af2d7318de9c30763914a77a979</Hash>
</Codenesium>*/