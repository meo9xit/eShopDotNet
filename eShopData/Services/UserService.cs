using AutoMapper;
using eShopData.Context;
using eShopData.Core.IData;
using eShopData.DTOs;
using eShopData.Entities;
using eShopData.IService;

namespace eShopData.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<eShopContext> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repository;

        public UserService(IUnitOfWork<eShopContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetRepository<User>();
        }

        public void Delete(UserModel model)
        {
            _repository.Delete(model);
        }

        public async Task<UserModel> GetById(string id)
        {
            var entity = await _repository.GetFirstOrDefaultAsync(p=>p.Id == id);
            return _mapper.Map<UserModel>(entity);
        }

        public async Task<UserModel> Insert(UserModel model)
        {
            var entity = _mapper.Map<User>(model);
            var newEntity = await _repository.InsertAsync(entity);
            var userModel = _mapper.Map<UserModel>(newEntity.Entity);
            await _unitOfWork.SaveChangesAsync();
            return userModel;
        }

        public async Task<UserModel> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> Update(UserModel model)
        {
            var entity = await _repository.GetFirstOrDefaultAsync(p => p.Id == model.Id);
            if (entity == null)
                return null;
            _mapper.Map(model, entity);
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }
    }
}
