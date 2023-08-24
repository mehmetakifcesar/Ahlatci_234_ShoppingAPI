﻿using Shopping.DAL.Abstract.DataManagement;
using ShoppingAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Abstract
{
    public interface ICartRepository:IRepository<Cart>
    {
       
    }
}
