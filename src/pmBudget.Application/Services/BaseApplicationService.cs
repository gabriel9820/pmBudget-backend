using AutoMapper;
using pmBudget.Application.Exceptions;
using pmBudget.Application.Interfaces;
using pmBudget.Domain.Entities.Base;
using pmBudget.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace pmBudget.Application.Services
{
    public abstract class BaseApplicationService<TEntity, TInputModel, TOutputModel> : IBaseApplicationService<TEntity, TInputModel, TOutputModel>
        where TEntity : BaseEntity
        where TInputModel : class
        where TOutputModel : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BaseApplicationService(IBaseRepository<TEntity> baseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TOutputModel> CreateAsync(TInputModel inputModel)
        {
            var entity = _mapper.Map<TEntity>(inputModel);
            var createdEntity = _baseRepository.Create(entity);
            await _unitOfWork.Commit();

            return _mapper.Map<TOutputModel>(createdEntity);
        }

        public async Task<TOutputModel> UpdateAsync(long id, TInputModel inputModel)
        {
            var entity = await _baseRepository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            _mapper.Map(inputModel, entity);
            var updatedEntity = _baseRepository.Update(entity);
            await _unitOfWork.Commit();

            return _mapper.Map<TOutputModel>(updatedEntity);
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _baseRepository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            _baseRepository.Delete(entity);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<TOutputModel>> FindAsync(Expression<Func<TEntity, bool>>? conditions = null, int? skip = null, int? take = null, params Expression<Func<TEntity, object>>[]? includes)
        {
            var entities = await _baseRepository.FindAsync(conditions, skip, take, includes);

            return _mapper.Map<IEnumerable<TOutputModel>>(entities);
        }

        public async Task<TOutputModel> GetByIdAsync(long id)
        {
            var entity = await _baseRepository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<TOutputModel>(entity);
        }
    }
}
