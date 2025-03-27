using FalzoniNetApi.Domain.Dtos.Base;
using FalzoniNetApi.Domain.Entities.Base;
using FalzoniNetApi.Domain.Interfaces.Repositories.Base;
using FalzoniNetApi.Domain.Interfaces.Services.Base;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using NUnit.Framework.Legacy;

namespace FalzoniNetApi.Unit.Test;

public abstract class BaseServiceTest<TEntity, TDTO> 
    where TEntity : BaseEntity, new()
    where TDTO : BaseDTO, new()
{
    protected IBaseService<TDTO>? _service;

    [SetUp]
    public void Setup()
    {
        _service = GetService();
    }

    public virtual void Test_GetAll_Success()
    {
        var list = _service!.GetAll();

        Assert.That(list.Count, Is.EqualTo(9));
    }

    public virtual void Test_Get_Success(Guid id)
    {
        var obj = _service!.Get(id);

        ClassicAssert.IsNotNull(obj);
        Assert.That(obj.Id, Is.EqualTo(id));
    }

    public virtual void Test_Create_Success()
    {
        TDTO obj = SetObject();

        _service!.Create(obj);
    }

    public virtual void Test_Update_Success()
    {
        TDTO obj = SetObject();

        _service!.Create(obj);
    }

    public virtual void Test_Delete_Success()
    {
        Guid id = Guid.NewGuid();

        _service!.Delete(id);
    }

    #region Protected Methods
    protected IUnitOfWork GetUnitOfWork()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.GetTransaction()).Returns(new Mock<IDbContextTransaction>().Object);
        
        return mockUnitOfWork.Object;
    }
    #endregion

    #region Abstract Methods
    protected abstract TDTO SetObject();

    protected abstract IBaseService<TDTO> GetService();

    protected abstract IBaseRepository<TEntity> GetRepository();

    protected abstract List<TEntity> GetData();
    #endregion
}
