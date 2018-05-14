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
	public abstract class AbstractLessonXTeacherRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLessonXTeacherRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOLessonXTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOLessonXTeacher Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOLessonXTeacher Create(
			LessonXTeacherModel model)
		{
			LessonXTeacher record = new LessonXTeacher();

			this.Mapper.LessonXTeacherMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<LessonXTeacher>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.LessonXTeacherMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			LessonXTeacherModel model)
		{
			LessonXTeacher record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LessonXTeacherMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			LessonXTeacher record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LessonXTeacher>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOLessonXTeacher> Where(Expression<Func<LessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOLessonXTeacher> SearchLinqPOCO(Expression<Func<LessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLessonXTeacher> response = new List<POCOLessonXTeacher>();
			List<LessonXTeacher> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.LessonXTeacherMapEFToPOCO(x)));
			return response;
		}

		private List<LessonXTeacher> SearchLinqEF(Expression<Func<LessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonXTeacher.Id)} ASC";
			}
			return this.Context.Set<LessonXTeacher>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LessonXTeacher>();
		}

		private List<LessonXTeacher> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonXTeacher.Id)} ASC";
			}

			return this.Context.Set<LessonXTeacher>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LessonXTeacher>();
		}
	}
}

/*<Codenesium>
    <Hash>e8771aa74ef9d7f5af7012a1ab7ac2fa</Hash>
</Codenesium>*/