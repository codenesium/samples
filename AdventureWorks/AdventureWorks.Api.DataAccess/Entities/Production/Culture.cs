using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Culture", Schema="Production")]
        public partial class Culture : AbstractEntity
        {
                public Culture()
                {
                }

                public virtual void SetProperties(
                        string cultureID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [Key]
                [Column("CultureID")]
                public string CultureID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f8fced99b2e37bd17cf7969e8ec3dfb9</Hash>
</Codenesium>*/