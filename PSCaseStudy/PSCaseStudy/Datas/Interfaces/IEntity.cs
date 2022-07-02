﻿namespace PSCaseStudy.Datas.Interfaces
{
    public interface IEntity<TKey> where TKey : notnull
    {
        public TKey Id { get; set; }
    }
}
