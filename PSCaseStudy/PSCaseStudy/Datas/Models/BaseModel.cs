using MessagePack;
using PSCaseStudy.Datas.Interfaces;
using System;

namespace PSCaseStudy.Datas.Models
{
    [Serializable]
    [MessagePackObject]
    public abstract class BaseModel<TKey> : IModel<TKey>
    {
        [Key(0)]
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public int isDeleted { get; set; }
    }

    public abstract class BaseModel : BaseModel<int> { }
}
