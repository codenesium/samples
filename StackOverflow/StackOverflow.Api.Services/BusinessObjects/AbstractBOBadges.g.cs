using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractBOBadges : AbstractBusinessObject
        {
                public AbstractBOBadges()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  DateTime date,
                                                  string name,
                                                  int userId)
                {
                        this.Date = date;
                        this.Id = id;
                        this.Name = name;
                        this.UserId = userId;
                }

                public DateTime Date { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8d448202eb0b1a38ad12e525e082b325</Hash>
</Codenesium>*/