﻿using Auto_Manager_Hub.DataAccess.Data;
using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public class SubModelRepository : Repository<SubModel>, ISubModelRepository
    {
        public SubModelRepository(AppDbContext context):base(context) { }   

        public void Update(SubModel entity)
        {
            _context.Update(entity);
        }
    }
}
