﻿using ProjEvento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjEvento.Persistence.Interfaces
{
    public interface IGeralPersistence
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void DeleteRange<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
    }
}
