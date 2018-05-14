using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractStudentXFamilyRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStudentXFamilyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOStudentXFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOStudentXFamily Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOStudentXFamily Create(
			StudentXFamilyModel model)
		{
			StudentXFamily record = new StudentXFamily();

			this.Mapper.StudentXFamilyMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<StudentXFamily>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.StudentXFamilyMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			StudentXFamilyModel model)
		{
			StudentXFamily record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.StudentXFamilyMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			StudentXFamily record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<StudentXFamily>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOStudentXFamily> Where(Expression<Func<StudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOStudentXFamily> SearchLinqPOCO(Expression<Func<StudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStudentXFamily> response = new List<POCOStudentXFamily>();
			List<StudentXFamily> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.StudentXFamilyMapEFToPOCO(x)));
			return response;
		}

		private List<StudentXFamily> SearchLinqEF(Expression<Func<StudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(StudentXFamily.Id)} ASC";
			}
			return this.Context.Set<StudentXFamily>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<StudentXFamily>();
		}

		private List<StudentXFamily> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(StudentXFamily.Id)} ASC";
			}

			return this.Context.Set<StudentXFamily>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<StudentXFamily>();
		}
	}
}

/*<Codenesium>
    <Hash>69172c0f836059970e6ebbdd403dcfb8</Hash>
</Codenesium>*/