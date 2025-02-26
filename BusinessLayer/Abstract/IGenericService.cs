﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void Add(T t);
        void AddRange(List<T> t);

        void Remove(int id);
        void Update(T t);
        List<T> GetList();
        T GetById(int id);

    }
}
