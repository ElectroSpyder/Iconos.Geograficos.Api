﻿namespace Base.Repository.IRepository
{
    using Iconos.Geograficos.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IIconoRepository
    {
        Task<IEnumerable<IconosReograficos>> GetAll();
        Task<IconosReograficos> Get(int id);
        Task<IconosReograficos> Add(IconosReograficos entity);
        Task<IconosReograficos> Update(IconosReograficos entity);
        Task<IconosReograficos> Delete(int id);
        Task<IEnumerable<IconosReograficos>> GetByFunc(Expression<Func<IconosReograficos, bool>> filter);
    }
}
