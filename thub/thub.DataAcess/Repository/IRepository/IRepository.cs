﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace thub.DataAcess.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T GetFirstOrDefault(Expression<Func<T, bool>> filter);
		void Add(T entity);
		void Delete(T entity);
		void DeleteRange(IEnumerable<T> entities);
	}
}
