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
	public abstract class AbstractStudentRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStudentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOStudent Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOStudent Create(
			ApiStudentModel model)
		{
			Student record = new Student();

			this.Mapper.StudentMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Student>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.StudentMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiStudentModel model)
		{
			Student record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.StudentMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Student record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Student>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOStudent> Where(Expression<Func<Student, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOStudent> SearchLinqPOCO(Expression<Func<Student, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStudent> response = new List<POCOStudent>();
			List<Student> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.StudentMapEFToPOCO(x)));
			return response;
		}

		private List<Student> SearchLinqEF(Expression<Func<Student, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Student.Id)} ASC";
			}
			return this.Context.Set<Student>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Student>();
		}

		private List<Student> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Student.Id)} ASC";
			}

			return this.Context.Set<Student>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Student>();
		}
	}
}

/*<Codenesium>
    <Hash>369dfb84f436172304f281ef98c9818c</Hash>
</Codenesium>*/