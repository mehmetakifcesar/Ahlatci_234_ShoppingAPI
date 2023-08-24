namespace Shopping.DAL.Abstract.DataManagement
{
    public interface IUnitOfWork
    {

        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICartRepository CartRepository { get; }

        Task<int> SaveChangeAsync();
    }
}
