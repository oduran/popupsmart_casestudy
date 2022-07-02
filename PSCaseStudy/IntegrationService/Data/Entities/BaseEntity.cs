using PSCaseStudy.Datas.Enums;
using PSCaseStudy.Datas.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegrationService.Data.Entities
{

    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int> { }
}
