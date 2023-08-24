using Shopping.Business.Abstract;
using Shopping.DAL.Abstract.DataManagement;
using ShoppingAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cart> AddAsync(Cart Entity)
        {
           await _unitOfWork.CartRepository.AddAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
            return Entity;

        }

        public Task<IEnumerable<Cart>> GetAllAsync(Expression<Func<Cart, bool>> Filter = null, params string[] IncludeProperties)
        {
            return _unitOfWork.CartRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public Task<Cart> GetAsync(Expression<Func<Cart, bool>> Filter, params string[] IncludeProperties)
        {
            return _unitOfWork.CartRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Cart Entity)
        {
            await _unitOfWork.CartRepository.RemoveAsync(Entity);
            await _unitOfWork.SaveChangeAsync();

        }

        public async Task UpdateAsync(Cart Entity)
        {
            await _unitOfWork.CartRepository.UpdateAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
