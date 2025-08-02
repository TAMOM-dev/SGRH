using SGRH.Domain.Base;

namespace SGRH.Application.Base
{
    public interface IBaseService<TDtoSave, TDtoUpdate, TDtoRemove>
    {
        Task<OperationResult> GetAll();
        Task<OperationResult> GetById(int id);
        Task<OperationResult> Update(TDtoUpdate dto);
        Task<OperationResult> Remove(int id);
        Task<OperationResult> Save(TDtoSave dto);
    }
}
